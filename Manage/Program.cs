namespace Manage
{
    internal class Program
    {
        static void Main()
        {
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();
            AdminController adminController = new AdminController();
            TeacherController teacherController = new TeacherController();
        }
    }
}