using System.Collections.Generic;

namespace CF.BL
{
    public enum Gender
    {
        Male,
        Female
    }
    public abstract class Person
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }

        public Person() { }
        public Person(string fname, string mname, string lname, Address address)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            Address = address;
        }
        public Person(string fname, string mname, string lname) : this(fname, mname, lname, null) { }

        public string FullName
        {
            get
            {
                string output = "";
                if(!string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(FirstName))
                {
                    output = LastName + ", " + FirstName;
                }else if (string.IsNullOrWhiteSpace(LastName))
                {
                    output = FirstName;
                }
                else if (string.IsNullOrWhiteSpace(FirstName))
                {
                    output = LastName;
                }

                return output;
            }
        }

    }

    public class Parent: Person
    {
        public List<Person> Children { get; set; }
        public Parent()
        {
            Children = new List<Person>();
        }
    }

    public class Child : Person { }
    public class Ancestor: Parent { }
}
