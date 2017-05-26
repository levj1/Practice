using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HackerRank30Days.D2Operators();
            

            Console.ReadLine();
        }

        private static void ReadAndWriteFile()
        {
            // read file

            // If add number if not in loop 
            string path = @"C:\Users\James Leveille\Documents\GitHub\Practice\DeitelBookApp\numTransID.txt";
            string newPath = @"C:\Users\James Leveille\Documents\GitHub\Practice\DeitelBookApp\NEW.txt";

            if (File.Exists(newPath))
                File.Delete(newPath);

            if (!File.Exists(newPath))
            {
                File.Create(newPath);
            }

            StringBuilder sb = new StringBuilder();
            List<string> listTran = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                string oldTransid = "0";
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (var transId in line.Split(','))
                    {
                        if (transId != oldTransid)
                        {
                            listTran.Add(transId);
                            sb.Append(transId);
                            sb.Append(",");
                        }
                    }
                }
            }

            File.WriteAllLines(newPath, listTran.ToArray());
            // add to new file
            //using (StreamWriter sWriter = new StreamWriter(newPath))
            //{
            //    sWriter.Write(sb.ToString());
            //}
        }

        private static bool SimilarCharacterWords(string fWord, string sWord)
        {
            if (fWord.Length != sWord.Length)
                return false;
            List<int> indexFound = new List<int>();
            foreach (var item in fWord)
            {
                bool isCharFound = false;
                for (int i = 0; i < sWord.Length; i++)
                {
                    if (item == sWord[i] && !indexFound.Contains(i))
                    {
                        indexFound.Add(i);
                        isCharFound = true;
                        break;
                    }
                }
                if (!isCharFound)
                {
                    return false;
                }
            }

            return true;
        }

        private static object CheckNumberOfOcurrence(string fWord, char character)
        {
            throw new NotImplementedException();
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
