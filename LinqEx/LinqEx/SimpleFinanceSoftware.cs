using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx
{
    public class SimpleFinanceSoftware
    {
        public void AddDonation(Donation donation)
        {
            if (donation == null)
                throw new System.ArgumentException("Unable to add donation.");

            Initializer.DonationRepertoire.Add(donation);
        }

        public decimal GetTotalDonation()
        {
            decimal sum = Initializer.DonationRepertoire.Select(d => d.Amount).Sum();
            return sum;
        }

        public decimal GetTotalDonationPerPerson(int id)
        {
            var person = Initializer.PeopleInSystem.Select(p => p.ID == id);
            if (person == null)
                throw new System.ArgumentException("Person not found.");

            decimal totalDonationFromPerson = (from d in Initializer.DonationRepertoire
                                      where d.Giver.ID == id
                                      select d.Amount).Sum();
            return totalDonationFromPerson;
        }
    }
}
