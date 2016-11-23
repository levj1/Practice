using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceApp.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int AddressID { get; set; }


        public virtual Address Address { get; set; }
    }
}