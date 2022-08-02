using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    static class DbContext
    {
        static DbContext()
        {
            Drugs = new List<Drug>();
            Druggists = new List<Druggist>();
            Drugstores = new List<Drugstore>();
            Owners = new List<Owner>();
            Admins = new List<Admin>();
        }
    }
}
