using Core.Entities;
using Core.Helpers;
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

            Admins = new List<Admin>();
            string password1 = "1111";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("Raqif", hashedPassword1);
            Admins.Add(admin1);

            string password2 = "1234";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("Admin", hashedPassword2);
            Admins.Add(admin2);
        }
        public static List<Admin> Admins { get; set; }
        public static List<Owner> Owners { get; set; }
        public static List<Drugstore> Drugstores { get; set; }
        public static List<Druggist> Druggists { get; set; }
        public static List<Drug> Drugs { get; set; }
    }
}
