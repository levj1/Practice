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
            Person Paul = new Person("Paul");
            Person James = new Person("James");

            List<Donation> allDons = new List<Donation>
            {
                new Donation(1, 12.3M, DateTime.Now.AddMonths(-12), DonationType.Offering, Paul),
                new Donation(2, 125.00M, DateTime.Now.AddMonths(-12), DonationType.Tithe, Paul),
                new Donation(3, 10.00M, DateTime.Now.AddMonths(-10), DonationType.Offering, James),
                new Donation(4, 220, DateTime.Now.AddMonths(-10), DonationType.Tithe, James)
            };
            Console.ReadLine();
        }







        private static void LinqPractice2()
        {
            string[] presidents = {
                "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
                "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
                "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"
            };

            var aPresidents = presidents.Where(p => p.StartsWith("A")).ToList();
            var lengthFive = presidents.Where(p => p.Length < 5).ToList();
            var orderAsc = presidents.OrderBy(x => x).ToList();
            var descPres = from p in presidents
                           orderby p descending
                           select p;

            foreach (var pres in descPres)
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
