using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    class Person
    {
        public string Name { get; set; }
        public Account Account { get; set; }

        public Person(string name)
        {
            Name = name;
        }
        public Person()
        {

        }
    }
}
