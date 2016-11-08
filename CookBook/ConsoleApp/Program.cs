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
            string[] names = { "Kendall", "Woodeline", "Guy Eddy", "James", "Nathalie", "Danielle",
                "Eddyte", "Rodney", "Kelly", "Andy"};

            var nameList = new List<string>();
            nameList.AddRange(names);
            Console.WriteLine("list in unsorted order: ");
            foreach (var name in nameList)
            {
                Console.WriteLine("{0}", name);
            }

            nameList.Sort();

            Console.WriteLine("list in sorted order: ");
            foreach (var name in nameList)
            {
                Console.WriteLine("{0}", name);
            }

            Console.ReadLine();
        }
    }
}
