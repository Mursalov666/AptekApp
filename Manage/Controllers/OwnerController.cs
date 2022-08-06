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
    public class OwnerController
    {
        private OwnerRepository _ownerRepository;
        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }

        #region Create 

        public void CreateOwner()
        {
            Name: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please , enter owner name :");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name) && name!=" ")
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please , enter owner surname :");
                string surname = Console.ReadLine();

                var owner = new Owner
                {
                    Name = name,
                    Surname = surname
                };
                _ownerRepository.Create(owner);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"Name : {name} , Surname : {surname}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You don't have to enter a number");
                goto Name;
            }
        }

        #endregion

        #region Update
        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            Allowner: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All owner list:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"id : {owner.Id} , Name : {owner.Name} , Surname : {owner.Surname}");
                }

            Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please , enter owner id :");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        string oldName = owner.Name;
                        string oldSurname = owner.Surname;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please , enter new owner name :");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please , enter new owner surname :");
                        string newsurname = Console.ReadLine();

                        var newOwner = new Owner()
                        {

                            Name = newName,
                            Surname = newsurname,
                        };
                        _ownerRepository.Update(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Old name : {oldName} , Old surname : {oldSurname}; Owner update - New name : {newOwner.Name} , New surname : {newOwner.Surname}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                        goto Allowner;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any owner");
            }


        }

        #endregion

        #region Delete 
        public void DeleteOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
            AllOwner: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All owner list:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"id : {owner.Id} , name : {owner.Name} , surname : {owner.Surname}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please , enter owner id : ");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"id : {id} , name : {owner.Name} , surname : {owner.Surname} - deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                        goto AllOwner;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter id in correct formta");
                    goto id;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }

        #endregion

        #region GetAll
        public void GetAllOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All owner list :");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {owner.Id} , name : {owner.Name} , surname : {owner.Surname}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any owner");
            }
        }


        #endregion
    }
}
