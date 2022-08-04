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
    public class DrugstoreController
    {
        private DrugstoreRepository _drugstoreRepository;
        private DrugRepository _drugRepository;
        private OwnerRepository _ownerRepository;
        private DruggistRepository druggistRepository;
        public DrugstoreController()
        {
            _drugRepository = new DrugRepository();
            _drugstoreRepository = new DrugstoreRepository();
            _ownerRepository = new OwnerRepository();
        }
        #region Create

        public void Create()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter drugstore name :");
                string drugName = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter drugstore adress :");
                string drugAdress = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter drugstore contact number :");
                string drugNumber = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners :");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Owner id : {owner.Id} , Owner name :{owner.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , owner id :");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == chosenId);
                    if (owner != null)
                    {
                        Drugstore drugStore = new Drugstore()
                        {
                            Name = drugName,
                            Adress = drugAdress,
                            ContactNumber = drugNumber,
                            Owner = owner
                        };
                        var createDrugstore = _drugstoreRepository.Create(drugStore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Drugstore is succesfully created");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct id !");
                        goto Id;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any owners");
            }
        }

        #endregion

        #region Update 

        public void Update()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores list :");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"id : {drugstore.Id}, name : {drugstore.Name}, adress : {drugstore.Adress}, contactnumber : {drugstore.ContactNumber}");

                }
                id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter drugstore id :");
                int chosenId;
                string Id = Console.ReadLine();
                var result = int.TryParse(Id, out chosenId);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == chosenId);
                    if (drugstore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please , enter new name :");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please , enter new adress :");
                        string newAdress = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please , enter new contactnumber");
                        string newNumber = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners list :");
                        var owners = _ownerRepository.GetAll();
                        foreach (var owner in owners)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"Owner's id : {owner.Id}, owner's : {owner.Name} ");
                        }
                        id1: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please , enter owner id :");
                        int ownerId;
                        string id = Console.ReadLine();
                        var results = int.TryParse(id, out ownerId);
                        if (results)
                        {
                            var owner = _ownerRepository.Get(o => o.Id == ownerId);
                            if (owner != null)
                            {
                                Drugstore drugstore1 = new Drugstore()
                                {
                                    Id = drugstore.Id,
                                    Name = newName,
                                    Adress = newAdress,
                                    ContactNumber = newNumber,
                                    Owner = owner
                                };
                                var creatDrugstore = _drugstoreRepository.Create(drugstore);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Drugstore is successfully updated {drugstore.Name} {drugstore.Adress} {drugstore.ContactNumber}");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct id !");
                                goto id1;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format !");
                            goto id1;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct id !");
                        goto id;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format");
                    goto id;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any drugstores");
            }
        }

        #endregion

        #region Delete

        public void Delete()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores list :");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $" Drugstore id : {drugstore.Id} Owner : {drugstore.Owner.Name}");
                }
                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please , enter drugstore id :");
                int chosenId;
                string id = Console.ReadLine();
                var result = int.TryParse(id, out chosenId);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == chosenId);
                    if (drugstore != null)
                    {
                        string name = drugstore.Name;
                        _drugstoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"{name} is successfuly deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct id !");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format");
                    goto Id;
                }
            }
        }

        #endregion

        #region GetAll

        public void GetAll()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores list :");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $" Owner : {drugstore.Owner.Name} {drugstore.Owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There ary no any drugstores");
            }
        }

        #endregion

        #region GetAllDrugstoresByOwner

        public void GetAllDrugstoresByOwner()
        {
            var drugstores = _drugstoreRepository.GetAll();
            var ownerstores = _ownerRepository.GetAll();
            if (true)
            {
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"Owner : {drugstore.Owner.Name} {drugstore.Owner.Surname}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, " There are no owners and drugstores");
            }
        }
        #endregion

        #region Sale 
        public void Sale()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count>0)
            {
              AllDrugs:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugs : ");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drug.Id} , name : {drug.Name} , price : {drug.Price} , count : {drug.Count}");
                }
               id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter drugs id :");
                string drugId=Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug!=null)
                    {
                      DrugsCount:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter drug count : ");
                        string drugCount = Console.ReadLine();
                        int count;
                        result=int.TryParse(drugCount,out count);
                        if (result)
                        {
                            if (count<drug.CurrentCount)
                            {

                                drug.CurrentCount = drug.CurrentCount - count;
                               double SumPrice= drug.Price * count;
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "This drug is available in the pharmacy. Do you want to buy??? (yes or no)");
                                string text=Console.ReadLine();
                                if (text=="yes".ToLower())
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"id : {drug.Id} , Name : {drug.Name} , Sumprice : {SumPrice} Drugstore - id : {drug.Id} , Name : {drug.Name} , Drugcount:{drug.CurrentCount}");
                                }
                                else if (text=="no".ToLower())
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Thank you");
                                }
                              
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This amount of drug is not available in the pharmacy");
                                goto DrugsCount; 
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter count in correct format");
                            goto DrugsCount;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                        goto AllDrugs;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct format");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }

        #endregion
    }
}
