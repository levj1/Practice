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
                    new Person {FirstName = "Kendall" },
                    new Person {FirstName = "Guy" },
                    new Person {FirstName = "James" },
                    new Parent {
                        FirstName = "Nathy",
                        Children = {
                            new Person { FirstName = "Abbie" }
                        }
                    }
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
                if (children is Parent)
                {
                }
            }
        }
    }
}
