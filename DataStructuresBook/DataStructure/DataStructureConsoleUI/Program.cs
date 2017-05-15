using System;

namespace DataStructureConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Name myName = new Name("James", "No", "Leveille");
            Console.WriteLine(myName.ToString());
            Console.WriteLine(myName.Initials());

            Console.ReadLine();
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
