using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateParkingCharge(23));

            Console.ReadLine();
        }

        private static decimal GenerateParkingCharge(int hour)
        {
            decimal charge = 0M;
            if (hour <= 3)
            {
                charge = 2.00M;
            }else if(hour > 3 && hour < 24)
            {
                charge = 2 + (.5M * (hour - 3));
            }
            else
            {
                charge = 10;
            }
            return charge;
        }

        private static void PrintTrianglesPattern()
        {
            for (int i = 1; i < 10; i++)
            {
                PrintCharacterXTimes(i, '*');
                Console.WriteLine();
            }

            for (int i = 10; i > 0; i--)
            {
                PrintCharacterXTimes(i, 'a');

                Console.WriteLine();
            }

            // Print upside down

            for (int i = 1; i < 10; i++)
            {
                PrintCharacterXTimes(10 - i, ' ');
                PrintCharacterXTimes(i, '*');
                Console.WriteLine();
            }

            for (int i = 10; i > 0; i--)
            {
                PrintCharacterXTimes(10 - i + 1, ' ');
                PrintCharacterXTimes(i, 'a');

                Console.WriteLine();
            }
        }

        private static void PrintCharacterXTimesUpsideDown(int max, char aChar)
        {
            int i = 1;
            while (i < max)
            {
                for (int j = 0; j < 10 - j; j++)
                {
                    Console.Write(' ');
                }
                i++;
            }
        }

        private static void PrintCharacterXTimes(int max, char aChar)
        {
            int i = 1;
            while (i < max)
            {
                Console.Write(aChar);
                i++;
            }
        }

        private static int Factorial(int numb)
        {
            if(numb == 0 || numb == 1)
            {
                return numb;
            }else
            {
                return (numb) * Factorial(numb - 1);
            }
        }

        private static int FindSmallOfIntergers()
        {
            int[] arrOfInt = { 12, 3, 4, 1, 2, 1, 3, 10, -3, 90, -9 };
            int smallest = int.MaxValue;

            foreach (var numb in arrOfInt)
            {
                if(numb < smallest)
                {
                    smallest = numb;
                }
            }

            return smallest;
        }
    }
}
