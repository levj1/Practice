using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.BL
{
    public class Person
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; } 

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
}
