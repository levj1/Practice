using System;
using System.Collections.Generic;
using System.Linq;

namespace DeitelBookApp
{
    public static class HackerRank30DaysChallenge
    {

        public static void D8Dictionary()
        {
            int numbOfEntries = Convert.ToInt32(Console.ReadLine());
            // Create Dictionary to hold name and number
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            for (int i = 0; i < numbOfEntries; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                phoneBook.Add(line[0], line[1]);
            }

            bool found = true;
            while (found)
            {
                string search = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(search))
                {
                    found = false;
                    break;
                }
                
                    if (phoneBook.ContainsKey(search))
                    {
                        Console.WriteLine(search + "=" + phoneBook[search]);
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
            }
        }

        public static void D7Array(){
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[arr.Length - 1 - i]);
                Console.Write(" ");
            }
        }
        public static void D6Review()
        {
            int count = 0;
            int numberOfTestCase = Convert.ToInt32(Console.ReadLine());
            while (count < numberOfTestCase)
            {
                string line = Console.ReadLine();
                PrintChar(line, true);
                Console.Write(" ");
                PrintChar(line, false);

                Console.WriteLine();
                count++;
            }

        }

        private static void PrintChar(string word, bool isEven)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (i % 2 == 0 && isEven)
                {
                    Console.Write(word[i]);
                }
                else if (i % 2 != 0 && !isEven)
                {
                    Console.Write(word[i]);
                }
            }
        }

        public static void D5Loops()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                //Console.WriteLine($"{n} x {i} = {n * i}");
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

        public static void CrosswordPuzzle()
        {
            /*  +-++++++++
                +-++++++++
                +-------++
                +-++++++++
                +-++++++++
                +------+++
                +-+++-++++
                +++++-++++
                +++++-++++
                ++++++++++
            */

            char[,] plusMinusArr = new char[10, 10];
            int col = 0;
            while (col < 10)
            {
                char[] valueEnter = Console.ReadLine().ToArray();
                for (int i = 0; i < valueEnter.Length; i++)
                {
                    plusMinusArr[col, i] = valueEnter[i];
                }
                col++;
            };

            string[] wordsEntered = Console.ReadLine().Split(';');

            Console.WriteLine("You entered: ");
            int numberOfRows = plusMinusArr.GetLength(0);
            int numberOfCols = plusMinusArr.GetLength(1);
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int x = 0; x < numberOfCols; x++)
                {
                    Console.Write(plusMinusArr[i, x].ToString());
                }
                Console.WriteLine();
            }
        }
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
                    if (types[i] == numb2)
                    {
                        if (i == 0) countType1++;
                        if (i == 1) countType2++;
                        if (i == 2) countType3++;
                        if (i == 3) countType4++;
                        if (i == 4) countType5++;
                    }
                }
            }

            int[] typeCount = new int[] { countType1, countType2, countType3, countType4, countType5 };
            int count = 0;
            foreach (var item in typeCount)
            {
                if (item == typeCount.Max())
                {
                    //Console.Write($"{types[count]}");
                    break;
                }
                count++;
            }

        }
    }
}
