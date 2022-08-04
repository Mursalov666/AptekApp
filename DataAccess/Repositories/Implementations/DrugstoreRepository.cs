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
    public class DrugstoreRepository : IRepository<Drugstore>
    {
        private static int id;

        public Drugstore Create(Drugstore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Drugstores.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Drugstore entity)
        {
            try
            {
                DbContext.Drugstores.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void Update(Drugstore entity)
        {
            try
            {
                var drugstore = DbContext.Drugstores.Find(g => g.Id == entity.Id);
                if (drugstore != null)
                {
                    drugstore.Name = entity.Name;
                    drugstore.Adress = entity.Adress;
                    drugstore.ContactNumber = entity.ContactNumber;
                      
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public Drugstore Get(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (true)
                {
                    return DbContext.Drugstores[0];
                }
                else
                {
                    return DbContext.Drugstores.Find(filter);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public List<Drugstore> GetAll(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (true)
                {
                    return DbContext.Drugstores;
                }
                else
                {
                    return DbContext.Drugstores.FindAll(filter);
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
