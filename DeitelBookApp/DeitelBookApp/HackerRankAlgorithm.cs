using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public static class HackerRankAlgorithm
    {
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
