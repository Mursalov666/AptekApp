using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class OwnerRepository : IRepository<Owner>
    {
        private static int id;

        public Owner Create(Owner entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Owners.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Owner entity)
        {
            try
            {
                DbContext.Owners.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void Update(Owner entity)
        {
            try
            {
                var owner = DbContext.Owners.Find(g => g.Id == entity.Id);
                if (owner != null)
                {
                    owner.Name = entity.Name;
                    owner.Surname = entity.Surname;

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public Owner Get(Predicate<Owner> filter = null)
        {
            try
            {
                if (true)
                {
                    return DbContext.Owners[0];
                }
                else
                {
                    return DbContext.Owners.Find(filter);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public List<Owner> GetAll(Predicate<Owner> filter = null)
        {
            try
            {
                if (true)
                {
                    return DbContext.Owners;
                }
                else
                {
                    return DbContext.Owners.FindAll(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
