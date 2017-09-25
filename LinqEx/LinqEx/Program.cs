using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx
{
    class TestP
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinqPractice2();

            Console.ReadLine();
        }
        

        private static void LinqPractice2()
        {
            TestP[] presidents = {
                new TestP {FName = "Adam", LName = "Test" },
                new TestP {FName = "Peace", LName = "Test1" },
                new TestP {FName = "Eff", LName = "Test" },
            };

            var aPresidents = (
                                from p in presidents
                                group p by p into newGroup
                                select newGroup
                                ).ToList();


            foreach (var pres in aPresidents)
            {
                Console.WriteLine(pres);
            }
        }

        private static void LinqSimpleQuery()
        {
            string[] words = { "Hello world", "hello you", "hello all" };

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
        }
    }
}
