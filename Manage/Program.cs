using Manage.Controllers;

namespace Manage
{
    internal class Program
    {
        static void Main()
        {
            DrugController drugController = new DrugController();
            DrugstoreController drugstoreController = new DrugstoreController();
            AdminController adminController = new AdminController();
        }
    }
}