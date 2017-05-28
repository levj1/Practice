using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CF.BL;
namespace CF.Tests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestPersonFullName()
        {
            // actual
            Parent person = new Parent();
            person.FirstName = "James";
            person.LastName = "Leveille";
            string actual = person.FullName;

            // expect
            string expect = "Leveille, James";

            // assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestPersonWithEmptyFirstName()
        {
            // actual
            Parent person = new Parent();
            person.FirstName = "";
            person.LastName = "Leveille";
            string actual = person.FullName;

            // expect
            string expect = "Leveille";

            // assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestPersonWithEmptyLastName()
        {
            // actual
            Parent person = new Parent();
            person.FirstName = "James";
            person.LastName = "";
            string actual = person.FullName;

            // expect
            string expect = "James";

            // assert
            Assert.AreEqual(expect, actual);
        }
    }
}
