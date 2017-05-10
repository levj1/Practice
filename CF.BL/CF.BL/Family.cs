using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.BL
{
    class Family
    {
        public List<Person> Persons { get; set; }

        public Family()
        {
            Persons = new List<Person>();
        }
    }
}
