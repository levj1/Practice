using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public Contact() { }
        public Contact(int id, string firstname, string lastname, Address address)
        {

        }
        public Contact(string firstname, string lastname, Address address)
        {

        }
    }
}
