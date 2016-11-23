using ChurchFinanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChurchFinanceApp.DAL
{
    public class ChurchInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ChurchContext>
    {
        protected override void Seed(ChurchContext context)
        {
            var members = new List<Member>
            {
                new Member {FirstName="James", MiddleName="", LastName="Leveille", AddressID = 1 },
                new Member {FirstName="Saint", MiddleName="Juste", LastName="Berrett", AddressID = 3 }
            };
            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var addresses = new List<Address>
            {
                new Address {StreetNumber = "1234", AddressLine1 = "Address Line 1", City = "Greenbelt", State = "MD", ZipCode = 21044 },
                new Address {StreetNumber = "4321", AddressLine1 = "Street Line 1", City = "Cityville", State = "DC", ZipCode = 21234 }
            };
            addresses.ForEach(s => context.Addresses.Add(s));
            context.SaveChanges();
        }
    }
}