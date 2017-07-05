using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqEx;
namespace FinanceAppTests
{
    [TestClass]
    public class SimpleFinanceSoftwareTests
    {
        SimpleFinanceSoftware soft;

        [TestMethod]
        public void GetTotalDonationTest()
        {
            soft = new SimpleFinanceSoftware();
            soft.AddDonation(new Donation(1, 12, DateTime.Now, DonationType.Offering, new Person("Paul")));
            soft.AddDonation(new Donation(1, 25, DateTime.Now.AddDays(-2), DonationType.Offering, new Person("Luke")));

            Assert.AreEqual(37.00M, soft.GetTotalDonation());
        }

        [TestMethod]
        public void GetTotalDonationPerPersonTest()
        {
            soft = new SimpleFinanceSoftware();
            soft.AddDonation(new Donation(1, 12, DateTime.Now, DonationType.Offering, new Person { ID = 1, Name = "Paul" }));
            soft.AddDonation(new Donation(2, 25, DateTime.Now.AddDays(-2), DonationType.Offering, new Person { ID = 2, Name = "James" }));
            Assert.AreEqual(25.00M, soft.GetTotalDonationPerPerson(2));

        }
    }
}
