using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public static class DataStructures
    {
        public static int HourGlass(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int maxSum = int.MinValue;
            int sum = 0;

            // length must be greater than 1
            if (rows > 1 && cols > 1)
            {
                for (int i = 0; i < rows - 2; i++)
                {
                    for (int j = 0; j < cols - 2; j++)
                    {
                        sum += arr[i, j] + arr[i, j + 1] + arr[i, j + 2] + arr[i + 1, j + 1] + arr[i + 2, j] + arr[i + 2, j + 1] + arr[i + 2, j + 2];
                        
                        if (sum >= maxSum)
                        {
                            maxSum = sum;
                        }
                        sum = 0;
                    }
                }
                return maxSum;
            }
            else
            {
                return 0;
            }
        }
    }
}
