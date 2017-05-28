using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    class Person
    {
        public int Age { get; set; }

        public Person(int initialAge)
        {
            if (initialAge < 0)
            {
                Console.WriteLine("Age is not valid, setting age to 0.");
            }
            else
            {
                Age = initialAge;
            }
        }
        public Person()
        {
        }

        public void amIOld()
        {
            if(Age < 13)
            {
                Console.WriteLine("You are young.");
            }else if(Age >= 13 && Age < 18)
            {
                Console.WriteLine("You are a teenager.");
            }else
            {
                Console.WriteLine("You are old.");
            }
        }

        public void yearPasses()
        {
            Age++;
        }
    }
}
