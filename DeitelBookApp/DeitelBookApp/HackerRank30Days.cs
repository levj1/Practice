using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public static class HackerRank30Days
    {
        public static void D2Operators()
        {
            string line = Console.ReadLine();
            decimal mealCost = Convert.ToDecimal(line);

            line = Console.ReadLine();
            decimal tipPercent = Convert.ToDecimal(line);

            line = Console.ReadLine();
            decimal taxPercent = Convert.ToDecimal(line);

            decimal tip = mealCost * (tipPercent / 100);
            decimal tax = mealCost * (taxPercent / 100);

            decimal totalCost = mealCost + tip + tax;

            Console.WriteLine(Math.Round(totalCost));

           
        }

        public static void D1DataType()
        {
            int i = 4;
            double d = 4.0;
            string s = "HackerRank";

            int i2 = 0;
            double d2 = 0.0;
            string s2 = "";
            i2 = Convert.ToInt16(Console.ReadLine());
            d2 = Convert.ToDouble(Console.ReadLine());
            s2 = Console.ReadLine();
            
            Console.WriteLine(i + i2);
            Console.WriteLine((d + d2).ToString("0.0"));
            Console.WriteLine(s + s2);
        }
    }
}
