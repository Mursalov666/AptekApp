using Core.Constants;
using Core.Helpers;
using Manage.Controllers;

namespace Manage
{
    internal class Program
    {
        static void Main()
        {
            DrugController _drugController = new DrugController();
            DrugstoreController _drugstoreController = new DrugstoreController();
            AdminController _adminController = new AdminController();
            DruggistController _druggistController = new DruggistController();
            OwnerController _ownerController = new OwnerController();

        admin: var admin = _adminController.Authenticate();
            if (admin != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome {admin.Username}");
                Console.WriteLine("----------------------------------------------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Welcome my drugstore app :)");
                Console.WriteLine("----------------------------------------------------------");
                while (true)
                {
                main: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Main Menu:");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1 - Admin Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2 - Drug Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3 - Druggist Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4 - DrugStore Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5 - Owner Menu");

                    Console.WriteLine("----------------------------------------------------------");

                selectNumber: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Number :");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);

                    if (result)
                    {
                        if (selectedNumber == 1)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Logout UserName");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                        selectOption: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option :");
                            number = Console.ReadLine();
                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 1)
                            {

                                switch (selectedNumber)
                                {
                                    case (int)AdminOptions.Logout:
                                        goto admin;
                                        break;
                                    case (int)AdminOptions.BackMainMenu:
                                        goto main;
                                        break;
                                }

                            }

                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectOption;
                            }
                        }

                        else if (selectedNumber == 2)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "1 - Create Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "2 - Update Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "3 - Delete Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "4 - Get All");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "5 - Get All Drug By Store");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "6 - Filter");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");


                        selectOption1: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option :");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DrugOptions.CreateDrug:
                                        _drugController.CreateDrug();
                                        break;
                                    case (int)DrugOptions.UpdateDrug:
                                        _drugController.UpadateDrug();
                                        break;
                                    case (int)DrugOptions.DeleteDrug:
                                        _drugController.DeleteDrug();
                                        break;
                                    case (int)DrugOptions.GetAllDrug:
                                        _drugController.GetAllDrug();
                                        break;
                                    case (int)DrugOptions.GetAllDrugsByStore:
                                        _drugController.GetAllDrugsByStore();
                                        break;
                                    case (int)DrugOptions.DrugFilter:
                                        _drugController.DrugFilter();
                                        break;
                                    case (int)DrugOptions.BackMainMenu:
                                        goto main;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectOption1;
                            }
                        }
                        else if (selectedNumber == 3)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "1 - Create Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "2 - Update Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "3 - Delete Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "4 - Get All Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "5 - Get Drugist By Store");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");

                        selectOption2: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option :");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 5)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DruggistOptions.CreateDruggist:
                                        _druggistController.CreateDruggist();
                                        break;
                                    case (int)DruggistOptions.UpdateDruggist:
                                        _druggistController.UpdateDruggist();
                                        break;
                                    case (int)DruggistOptions.DeleteDruggist:
                                        _druggistController.DeleteDruggist();
                                        break;
                                    case (int)DruggistOptions.GetAllDruggist:
                                        _druggistController.GetAllDruggist();
                                        break;
                                    case (int)DruggistOptions.GetAllDruggistByDrugStore:
                                        _druggistController.GetAllDruggistByDrugStore();
                                        break;
                                    case (int)DruggistOptions.BackToMainMenu:
                                        goto main;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectOption2;
                            }

                        }
                        else if (selectedNumber == 4)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get All DrugStore By Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Sale");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");

                        selectOption3: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option :");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DrugstoreOptions.CreateDrugstore:
                                        _drugstoreController.CreateDrugstore();
                                        break;
                                    case (int)DrugstoreOptions.UpdateDrugstore:
                                        _drugstoreController.UpdateDrugstore();
                                        break;
                                    case (int)DrugstoreOptions.DeleteDrugstore:
                                        _drugstoreController.DeleteDrugstore();
                                        break;
                                    case (int)DrugstoreOptions.GetAllDrugstore:
                                        _drugstoreController.GetAllDrugstore();
                                        break;
                                    case (int)DrugstoreOptions.GetAllDrugstoreByOwner:
                                        _drugstoreController.GetAllDrugstoreByOwner();
                                        break;
                                    case (int)DrugstoreOptions.DrugstoreSale:
                                        _drugstoreController.DrugstoreSale();
                                        break;
                                    case (int)DrugstoreOptions.BackToMainMenu:
                                        goto main;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectOption3;
                            }
                        }
                        else if (selectedNumber == 5)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "1 - Create Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "2 - Update Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "3 - Delete Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "4 - Get All Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "0 - Back To Main Menu");

                            Console.WriteLine("----------------------------------------------------------");

                        selectOption4: ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Select Option :");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)OwnerOptions.CreateOwner:
                                        _ownerController.CreateOwner();
                                        break;
                                    case (int)OwnerOptions.UpdateOwner:
                                        _ownerController.UpdateOwner();
                                        break;
                                    case (int)OwnerOptions.DeleteOwner:
                                        _ownerController.DeleteOwner();
                                        break;
                                    case (int)OwnerOptions.GetAllOwner:
                                        _ownerController.GetAllOwner();
                                        break;
                                    case (int)OwnerOptions.BackToMainMenu:
                                        goto main;
                                        break;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The number you selected is not available");
                                goto selectOption4;
                            }
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter number in correct format !");
                        goto selectNumber;
                    }

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct password and username");
                goto admin;
            }
        }
    }
}