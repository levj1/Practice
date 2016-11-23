using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CF.WebMVC.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }

    public class MemberDBContext: DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}