using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePrac
{
    class Program
    {
        public delegate void Del(string message);
        public delegate int SumOfNumberDel(int a, int b);
        static void Main(string[] args)
        {
            // Instantiate delegae 
            Del delegaeHandler = DelegateMethod;
            SumOfNumberDel sumDel = SumOfNumber;

            delegaeHandler("World");
            Console.WriteLine(sumDel(20, 30));

            Console.ReadLine();
        
        }

        private static int SumOfNumber(int a, int b)
        {
            return a + b;
        }

        //Create a method for the delegate 
        static public void DelegateMethod(string message)
        {
            Console.WriteLine($"Hello {message}");
        }
    }
}
