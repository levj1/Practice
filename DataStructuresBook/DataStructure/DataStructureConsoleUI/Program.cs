using System;
using System.Diagnostics;

namespace DataStructureConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentTest tests = CreateQueueData();

            PrintTestInQueue(tests);

            tests.LookAtATest(new Student(3, "Guy"));

            PrintTestInQueue(tests);

            Console.ReadLine();
        }

        private static StudentTest CreateQueueData()
        {
            StudentTest tests = new StudentTest();
            tests.TurnInTest(new Student(1, "Ken"));
            tests.TurnInTest(new Student(2, "Dine"));
            tests.TurnInTest(new Student(3, "Guy"));
            tests.TurnInTest(new Student(4, "James"));
            return tests;
        }

        private static void PrintTestInQueue(StudentTest tests)
        {
            foreach (var test in tests.AllTests)
            {
                Console.WriteLine($"{test.Name} {test.TestId}");
            }
        }

        private static void BuildArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
        }

        static void DisplayNums(int[] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0); i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
        }
        private static void TestSwapGenericFunction()
        {
            int num1 = 100;
            int num2 = 200;
            Console.WriteLine($"num1 = {num1}");
            Console.WriteLine($"num2 = {num2}");

            Swap<int>(ref num1, ref num2);
            Console.WriteLine($"num1 = {num1}");
            Console.WriteLine($"num2 = {num2}");

            string fname = "James";
            string lname = "Leveille";

            Console.WriteLine($"First Name = {fname}");
            Console.WriteLine($"Last Name = {lname}");
            Swap<string>(ref fname, ref lname);
            Console.WriteLine($"First Name = {fname}");
            Console.WriteLine($"Last Name = {lname}");
        }

        private static void TestCollection()
        {
            MyCollection names = new MyCollection();
            names.Add("David");
            names.Add("Bernica");
            names.Add("Raymond");
            names.Add("Clayton");

            foreach (var item in names)
            {
                Console.WriteLine($"number of names: {names.Count()}");
            }

            names.Remove("Raymond");

            Console.WriteLine($"number of names: {names.Count()}");

            names.Clear();
            Console.WriteLine($"number of names: {names.Count()}");
        }

        private static void Swap<T>(ref T val1, ref T val2)
        {
            T Temp;
            Temp = val1;
            val1 = val2;
            val2 = Temp;
        }
    }

    public struct Name
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Name(string fname, string mname, string lname)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
        }

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }

        public string Initials()
        {
            return $"{FirstName.Substring(0, 1)} {MiddleName.Substring(0, 1)} {LastName.Substring(0, 1)}";
        }
    }
}
