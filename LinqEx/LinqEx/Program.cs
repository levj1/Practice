using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Hello world", "hello you", "hello all"};

            var items = from s in words
                        where s.EndsWith("all")
                        select s;
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }

            string[] numbers = { "012", "230", "0034" };
            int[] numbs = numbers.Select(x => int.Parse(x)).OrderBy(s => s).ToArray();

            foreach (var item in numbs)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
