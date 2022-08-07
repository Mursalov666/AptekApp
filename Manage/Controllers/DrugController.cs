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
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugstoreRepository _drugstoreRepository;
        public DrugController()
        {
            _drugRepository = new DrugRepository();
            _drugstoreRepository = new DrugstoreRepository();
        }

        #region Create
        public void CreateDrug()
        {
            var drugstores = _drugstoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug name :");
                string drugName = Console.ReadLine();
            drugPrice: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug price:");
                string priceDrug = Console.ReadLine();
                double price;
                bool result = double.TryParse(priceDrug, out price);
                if (result)
                {
                drugCount: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug count:");
                    string countDrug = Console.ReadLine();
                    int count;
                    result = int.TryParse(countDrug, out count);

                    if (result)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores:");
                        foreach (var drugstore in drugstores)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drugstore.Id} , name : {drugstore.Name} , adress : {drugstore.Adress} , contactNumber:{drugstore.ContactNumber} ");
                        }
                    DrugstoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drugstore id :");
                        string storeId = Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugstoreRepository.Get(d => d.Id == id);
                            if (drugStore != null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Price = price,
                                    Count = count,
                                    Drugstores = drugStore,
                                };
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"name : {drugName} , price : {priceDrug} , count : {count} , drugstore : {drug.Drugstores.Name} is created drug");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore is empty");
                                goto DrugstoreId;
                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                            goto DrugstoreId;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter drug count in correct format !");
                        goto drugCount;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter price in correct format !");
                    goto drugPrice;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }
        #endregion

        #region Update
        public void UpadateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugs list : ");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drug.Id} , name : {drug.Name} , price : {drug.Price} , count : {drug.Count} , drugstore : {drug.Drugstores.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug id:");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        string oldname = drug.Name;
                        double oldprice = drug.Price;
                        int oldcount = drug.Count;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new drug name :");
                        string newName = Console.ReadLine();
                    Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new drug price :");
                        string newPrice = Console.ReadLine();
                        double price;
                        result = double.TryParse(newPrice, out price);
                        if (result)
                        {
                        Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter new drug count");
                            string newCount = Console.ReadLine();
                            int count;
                            result = int.TryParse(newCount, out count);
                            if (result)
                            {

                                drug.Name = newName;
                                drug.Price = price;
                                drug.Count = count;

                                _drugRepository.Update(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Oldname : {oldname} , Oldprice : {oldprice} , Oldcount : {oldcount} is update to: name:{newName} , price : {price} , count : {count}");

                            }
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter count in correct format");
                            goto Count;
                        }
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter price in correct format");
                        goto Price;
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugs");
            }
        }

        #endregion

        #region Delete 
        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugs list : ");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"id : {drug.Id} , name:{drug.Name} , price : {drug.Price} , count:{drug.Count} drugstore:{drug.Drugstores.Name}");
                }
            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug id :");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"id : {drug.Id} , name:{drug.Name} - Deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }


        #endregion

        #region GetAll
        public void GetAllDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drug list :");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drug.Id} , name : {drug.Name} , price : {drug.Price} , count : {drug.Count} , drugstore : {drug.Drugstores.Name}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any owner");
            }
        }
        #endregion

        #region GetAllDrugsByDrugstore
        public void GetAllDrugsByStore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores list :");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drugstore.Id} , name : {drugstore.Name} , adress : {drugstore.Adress} , contactNumber : {drugstore.ContactNumber}");
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
                        var drugs = _drugRepository.GetAll(d => d.Drugstores != null ? d.Drugstores.Id == drugstore.Id : false);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "The drugs of drugsore :");
                        foreach (var drug in drugs)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drug.Id} , name : {drug.Name} , price : {drug.Price} , count : {drug.Count}");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstores");
            }
        }
        #endregion

        #region Filter
        public void DrugFilter()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter filter price :");
                string filterprice = Console.ReadLine();
                double price;
                bool result = double.TryParse(filterprice, out price);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All drugs list :");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price <= price)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"id : {drug.Id} , name : {drug.Name} , price : {drug.Price} , count : {drug.Count}");
                        }


                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter price in correct format !");
                    goto Price;
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
