using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public static class HackerRankAlgorithm
    {

        public static int[] Solve(int[] grades)
        {
            int[] newGrades = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] > 37)
                {
                    int nextMultiple = NextMultipleOf5(grades[i]);
                    if((nextMultiple - grades[i]) < 3){
                        newGrades[i] = nextMultiple;
                    }
                    else
                    {
                        newGrades[i] = grades[i];
                    }
                }
                else
                {
                    newGrades[i] = grades[i];
                }
            }

            return newGrades;
        }

        public static int NextMultipleOf5(int number)
        {
            bool found = false;
            int nextOne = number;
            while (!found)
            {
                nextOne++;
                if (nextOne % 5 == 0)
                {
                    found = true;
                }
            }
            return nextOne;
        }

        public static void ConvertTime()
        {
            string line = Console.ReadLine();
            DateTime time = Convert.ToDateTime(line);

            Console.WriteLine(time.ToString("HH:mm:ss"));

        }

        public static void BirthdayCakeCandle()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] height_temp = Console.ReadLine().Split(' ');
            int[] height = Array.ConvertAll(height_temp, Int32.Parse);

            int max = height.Max();
            int count = 0;
            foreach (var hgt in height)
            {
                if (hgt == max)
                    count++;
            }

            Console.WriteLine(count);
        }

        public static void MinMax()
        {
            string[] line = Console.ReadLine().Split(' ');
            long[] numbers = new long[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                numbers[i] = Convert.ToInt64(line[i]);
            }

            long min = int.MaxValue;
            long max = 0;
            long sum = 0;

            List<long> listOfSum = new List<long>();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i != j)
                    {
                        sum += numbers[j];
                    }
                }
                listOfSum.Add(sum);
                sum = 0;
            }
            
            Console.WriteLine(listOfSum.Min() + " " + listOfSum.Max());
        }

        public static void StairCase()
        {
            int numbStairs = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= numbStairs; i++)
            {
                PrintCharacterXTimes(numbStairs - i, ' ');
                PrintCharacterXTimes(i, '*');
                Console.WriteLine();
            }
        }

        private static void PrintCharacterXTimes(int max, char aChar)
        {
            int i = 1;
            while (i <= max)
            {
                Console.Write(aChar);
                i++;
            }
        }

        public static void PlusMinus()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            string[] line = Console.ReadLine().Split(' ');

            double numPos = 0;
            double numNeg = 0;
            double numNeut = 0;

            for (int i = 0; i < number; i++)
            {
                double numbEntered = Convert.ToDouble(line[i]);

                if (numbEntered > 0)
                {
                    numPos++;
                }
                else if (numbEntered == 0)
                {
                    numNeg++;
                }
                else
                {
                    numNeut++;
                }
            }

            Console.WriteLine(Math.Round(numPos / number, 6).ToString("0.000000"));
            Console.WriteLine(Math.Round(numNeg / number, 6).ToString("0.000000"));
            Console.WriteLine(Math.Round(numNeut / number, 6).ToString("0.000000"));
        }
           
        public static void DiagonalDifference()
        {
            int squareValue = Convert.ToInt32(Console.ReadLine());
            int[,] arrOfSquare = new int[squareValue, squareValue];
            for (int i = 0; i < squareValue; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                for (int j = 0; j < squareValue; j++)
                {
                    arrOfSquare[i, j] = Convert.ToInt32(line[j]);
                }
            }
            int sum1 = 0;
            int sum2 = 0;

            // Sum of diagonal 1
            for (int i = 0; i < squareValue; i++)
            {
                for (int j = 0; j < squareValue; j++)
                {
                    if (i == j)
                    {
                        sum1 += arrOfSquare[i, j];
                    }
                }
            }

            // Sum of diagonal 2
            int count = squareValue;
            for (int i = 0; i < squareValue; i++)
            {
                for (int j = 0; j < squareValue; j++)
                {
                    if (j == count - 1)
                    {
                        sum2 += arrOfSquare[i, j];
                        count--;
                    }
                }
            }

            Console.WriteLine(Math.Abs(sum1 - sum2));
            
        }

        public static void CompareTheTriplets()
        {
            string[] tokens_a0 = Console.ReadLine().Split(' ');
            int a0 = Convert.ToInt32(tokens_a0[0]);
            int a1 = Convert.ToInt32(tokens_a0[1]);
            int a2 = Convert.ToInt32(tokens_a0[2]);
            string[] tokens_b0 = Console.ReadLine().Split(' ');
            int b0 = Convert.ToInt32(tokens_b0[0]);
            int b1 = Convert.ToInt32(tokens_b0[1]);
            int b2 = Convert.ToInt32(tokens_b0[2]);
            int[] result = Solve(a0, a1, a2, b0, b1, b2);
            Console.WriteLine(String.Join(" ", result));
            
        }

        private static int[] Solve(int a0, int a1, int a2, int b0, int b1, int b2)
        {
            int[] Aarray = { a0, a1, a2};
            int[] Barray = { b0, b1, b2 };
            int[] result = new int[2];
            int Apoints = 0;
            int Bpoints = 0;

            for (int i = 0; i < Aarray.Length; i++)
            {
                if (Aarray[i] > Barray[i])
                {
                    Apoints++;
                }
                else if (Barray[i] > Aarray[i])
                {
                    Bpoints++;
                }
            }

            result[0] = Apoints;
            result[1] = Bpoints;

            return result;

            
        }
    }
}
