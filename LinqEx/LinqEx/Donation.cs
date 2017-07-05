using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEx
{
    public enum DonationType
    {
        Tithe, Offering, Pledge, Other
    }
    public class Donation
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public DonationType DonationType { get; set; }
        public Person Giver { get; set; }

        public Donation()
        {

        }

        public Donation(int id, decimal amnt, DateTime date, DonationType donType, Person person)
        {
            ID = id;
            Amount = amnt;
            DonationDate = date;
            DonationType = donType;
            Giver = person;

        }
    }
}
