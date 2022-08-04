using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class DruggistController
    {
        private DruggistRepository _druggistRepository;
        private DrugstoreRepository _drugstoreRepository;
        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();
            _drugstoreRepository = new DrugstoreRepository();

        }
        #region Create
        public void CreateDruggist()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter druggist name :");
                string druggistName = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter druggist surname :");
                string druggistSurname = Console.ReadLine();
            Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter druggist age :");
                string druggistAge = Console.ReadLine();
                byte age;
                bool result = byte.TryParse(druggistAge, out age);
                if (result)
                {
                Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter druggist experience :");
                    string druggistExperience = Console.ReadLine();
                    double experience;
                    result = double.TryParse(druggistExperience, out experience);
                    if (result)
                    {
                    All: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All drugstores list :");
                        foreach (var drugstore in drugstores)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"id : {drugstore.Id} , name : {drugstore.Name} , owner : {drugstore.Owner.Name}");
                        }
                    Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drugstore id:");
                        string drugstoreId = Console.ReadLine();
                        int id;
                        result = int.TryParse(drugstoreId, out id);
                        if (result)
                        {
                            var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                            if (drugstore != null)
                            {
                                var druggist = new Druggist()
                                {
                                    Name = druggistName,
                                    Surname = druggistSurname,
                                    Age = age,
                                    Experience = experience,
                                    Drugstore = drugstore,


                                };
                                _druggistRepository.Create(druggist);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"id : {druggist.Id} , name : {druggist.Name} , age : {druggist.Age} , experience : {druggist.Experience} , drugstore : {druggist.Drugstore.Name}");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore id doesn't exist");
                                goto All;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format !");
                            goto Id;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter experience in correct format !");
                        goto Experience;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter age in correct format !");
                    goto Age;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }

        #endregion

        #region Update
        public void UpdateDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            var drugstores = _drugstoreRepository.GetAll();
            if (druggists.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All druggists list :");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {druggist.Id} , name : {druggist.Name} , age : {druggist.Age} , experience : {druggist.Experience} ");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter druggist id :");
                string druggistId = Console.ReadLine();
                int id;
                bool result = int.TryParse(druggistId, out id);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == id);
                    if (druggist != null)
                    {
                        string oldname = druggist.Name;
                        string oldsurname = druggist.Surname;
                        byte oldage = druggist.Age;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new druggist name :");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new druggist surname :");
                        string newSurname = Console.ReadLine();
                    Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new druggist age :");
                        string newAge = Console.ReadLine();
                        byte age;
                        result = byte.TryParse(newAge, out age);
                        if (result)
                        {
                        Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new druggist experience :");
                            string newExperience = Console.ReadLine();
                            double experience;
                            result = double.TryParse(newExperience, out experience);
                            if (result)
                            {
                           AllDrug: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores list :");
                                foreach (var drugstore in drugstores)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"id : {drugstore.Id} , name : {drugstore.Name}");
                                }
                            DrugstoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Please , enter drugstore id :");
                                string drugstoreId = Console.ReadLine();
                                int storeid;
                                result = int.TryParse(drugstoreId, out storeid);
                                if (result)
                                {
                                    var drugstore = _drugstoreRepository.Get(d => d.Id == storeid);
                                    if (drugstore != null)
                                    {
                                        var newDruggist = new Druggist()
                                        {
                                            Name = newName,
                                            Surname = newSurname,
                                            Age = age,
                                            Experience = experience,
                                            Drugstore = drugstore,

                                        };
                                        _druggistRepository.Update(druggist);
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Oldname : {oldname} , Oldsurname : {oldsurname} , Oldage : {oldage} Update to : Newname : {newName} , Newsurname : {newSurname} , Newage : {age} , Newexperience : {experience} , newDrugstore:{drugstore}");
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore id doesn't exist");
                                        goto AllDrug;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format!");
                                    goto DrugstoreId;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter experience in correct format!");
                                goto Experience;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter age in correct format!");
                            goto Age;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist doesn't exist");
                        goto All;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format!");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }

        #endregion

        #region Delete
        public void DeleteDruggist()
        {
            var druggists = _druggistRepository.GetAll();

            if (druggists.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All druggist :");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {druggist.Id} , name : {druggist.Name} , surname : {druggist.Surname} , experience : {druggist.Experience}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter druggist id :");
                string druggistId = Console.ReadLine();
                int id;
                bool result = int.TryParse(druggistId, out id);
                if (result)
                {
                    var druggist = _druggistRepository.Get(d => d.Id == id);
                    if (druggist != null)
                    {
                        _druggistRepository.Delete(druggist);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{druggist.Id} - deleted.");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This druggist id doesn't exist");
                        goto All;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format !");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Druggist");
            }
        }
        #endregion

        #region GetAll
        public void GetAllDruggist()
        {
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All druggist :");
                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $" id : {druggist.Id} , name : {druggist.Name} , surname : {druggist.Surname} , age : {druggist.Age} , experience : {druggist.Experience} ");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any druggist");
            }
        }

        #endregion

        #region GetAllDruggistByDrugstore
        public void GetAllDruggistByDrugStore()
        {

            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores :");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $" id : {drugstore.Id} , name : {drugstore.Name} , adress : {drugstore.Adress} , contactNumber : {drugstore.ContactNumber} ");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drugstore id :");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        var druggists = _druggistRepository.GetAll(d => d.Drugstore.Id == drugstore.Id);
                        if (druggists.Count != 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All druggist to drugstore:");
                            foreach (var druggist in druggists)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {druggist.Id} , name : {druggist.Name} , surname : {druggist.Surname} , age : {druggist.Age}");
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore are not druggists");
                            goto All;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugsore id doesn't exist");
                        goto All;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format");
                    goto Id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Drugstore");
            }
        }

        #endregion
    }
}
