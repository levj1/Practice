using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public Person()
        {

        }
    }
}
