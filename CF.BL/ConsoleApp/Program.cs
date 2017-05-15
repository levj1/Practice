using CF.BL;
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
            Parent rony = new Parent()
            {
                FirstName = "Rony",
                Children =
                {
                    new Kid {FirstName = "Kendall" }
                }
            };

            PrintNameOfParentAndChildren(rony);

            Console.ReadLine();
        }

        private static void PrintNameOfParentAndChildren(Parent parent)
        {
            foreach (var children in parent.Children)
            {
                Console.WriteLine(children.FirstName);
                
            }
        }
    }
}
