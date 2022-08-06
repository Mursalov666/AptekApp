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

        public void CreateDrugstore()
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

        public void UpdateDrugstore()
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

        public void DeleteDrugstore()
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

        public void GetAllDrugstore()
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

        public void GetAllDrugstoreByOwner()
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
        public void DrugstoreSale()
        {
            GetAllDrugstore();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , select drugstore id :");
            var id = Console.ReadLine();
            int drugstoreId;
            var results = int.TryParse(id, out drugstoreId);
            if (results)
            {
                var dbDrugstore = _drugstoreRepository.Get(d => d.Id == drugstoreId);
                if (dbDrugstore != null)
                {
                    var dbDrugs = _drugRepository.GetAll(d => d.Drugstores == dbDrugstore);
                    if (dbDrugs.Count > 0)
                    {
                        foreach (var drug in dbDrugs)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"Drug id : {drug.Id} , name : {drug.Name} , price : {drug.Price} , count : {drug.Count} ");
                        }
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug id :");
                        var drugid = Console.ReadLine();
                        int DrugId;
                        results = int.TryParse(drugid, out DrugId);
                        if (results)
                        {
                            var dbDrug = _drugRepository.Get(d => d.Id == DrugId);
                            if (dbDrug != null && dbDrug.Count > 0)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter count :");
                                var count = Console.ReadLine();
                                int dbcount;
                                results = int.TryParse(count, out dbcount);
                                if (results)
                                {
                                    if (dbcount <= dbDrug.Count)
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Sale price : {dbcount * dbDrug.Price}");
                                        dbDrug.Count -= dbcount;
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct count !");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any drugstore !");
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any drugs !");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct id !");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any drugs !");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any drugs !");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct count !");
            }
        }

        #endregion
    }
}
