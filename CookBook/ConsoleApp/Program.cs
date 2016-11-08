using AppImplementation;
using AppInterface;
using AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUser repository = new UserImplemenation();

            //List All Departments
            List<Users> usersList = repository.SelectAll().ToList();
            foreach (var user in usersList)
            {
                Console.WriteLine(user.UserName);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            
        }
    }
}
