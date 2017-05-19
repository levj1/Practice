using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Util
    {
        public static List<int> NumberA = new List<int> { 1, 2, 5, 10, 56, 12, 10, 0 };

        public static List<int> SortAscending(List<int> list)
        {
            return list.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Sort a list in descending order.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> SortDescending(List<int> list)
        {
            list = list.OrderBy(x => x).ToList();
            List<int> descList = new List<int>();
            descList = OrderListBackToFront(list);            
            return descList;
        }

        public static List<int> OrderListBackToFront(List<int> list)
        {
            List<int> backtoFront = new List<int>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                backtoFront.Add(list[i]);
            }

            return backtoFront;
        }

        public static void PrintListData(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Return the duplicate values in a list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> DuplicateValuesInList(List<int> list)
        {
            List<int> dupList = new List<int>();
            foreach (var item in list)
            {
                if(IsValueRepeated(list, item) && !dupList.Contains(item))
                {
                    dupList.Add(item);
                }
            }

            return dupList;
        }

        /// <summary>
        /// Check whether a value is repeated in a list
        /// </summary>
        public static bool IsValueRepeated(List<int> list, int numb)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item == numb)
                {
                    count++;
                }
            }
            return count > 1;
        }

        /// <summary>
        /// Check if a number is perfect. 
        /// A perfect number is equal to the sum of its factors. 
        /// </summary>
        public static bool IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number - 1; i++)
            {
                if (IsAFactor(number, i))
                {
                    sum += i;
                }
            }
            return (sum == number);
        }

        /// <summary>
        /// Sum the numbers before that number
        /// </summary>
        public static int SumOfNumberPrecendent(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static bool IsPrimeNumber(int number)
        {
            if (number == 1)
                return true;

            bool output = true;
            for (int i = 2; i < number - 1; i++)
            {
                if (IsAFactor(number, i))
                {
                    return false;
                }
            }
            return output;
        }

        /// <summary>
        /// Check if a number is a factor (divisible by)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        public static bool IsAFactor(int number, int factor)
        {
            return number % factor == 0;
        }
    }
}
