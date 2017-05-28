using System;
using System.Linq;

namespace DeitelBookApp
{
    public static class HackerRank30DaysChallenge
    {
        public static void MigratoryBirds()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] types_temp = Console.ReadLine().Split(' ');
            int[] types = Array.ConvertAll(types_temp, Int32.Parse);

            int countType1 = 0;
            int countType2 = 0;
            int countType3 = 0;
            int countType4 = 0;
            int countType5 = 0;
            for (int i = 0; i < types.Length; i++)
            {
                foreach (var numb2 in types)
                {
                    if(types[i] == numb2)
                    {
                        if (i == 0) countType1++;
                        if (i == 1) countType2++;
                        if (i == 2) countType3++;
                        if (i == 3) countType4++;
                        if (i == 4) countType5++;
                    }
                }
            }

            int[] typeCount = new int[] { countType1, countType2, countType3, countType4, countType5};
            int count = 0;
            foreach (var item in typeCount)
            {
                if (item == typeCount.Max())
                {
                    Console.Write($"{types[count]}");
                    break;
                }
                count++;
            }
            
        }
        public static void D3ConditionalStatement()
        {
            int n;
            n = Convert.ToInt16(Console.ReadLine());
            if (n % 2 != 0)
            {
                Console.WriteLine("Weird");
            }
            else if (n >= 2 && n <= 5)
            {
                Console.WriteLine("Not Weird");
            }
            else if (n % 2 == 0 && n >= 6 && n <= 20)
            {
                Console.WriteLine("Weird");
            }
            else if (n % 2 == 0 && n >= 20)
            {
                Console.WriteLine("Not Weird");
            }

            Console.ReadLine();
        }
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
            Console.WriteLine("The total meal cost is " + Math.Round(totalCost) + " dollars.");
        }

        public static void D1DataType()
        {
            int i = 4;
            double d = 4.0;
            string s = "HackerRank";

            int i2 = 0;
            double d2 = 0.0;
            string s2 = "";
            Console.WriteLine(i + i2);
            Console.WriteLine((d + d2).ToString("0.0"));
            Console.WriteLine(s + s2);
        }
    }
}
