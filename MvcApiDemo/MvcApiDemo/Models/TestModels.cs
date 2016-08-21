using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApiDemo.Models
{
    public class TestModels
    {
        public string Book { get; set; }
        public int Chapter { get; set; }

        public TestModels()
        {
            Book = "Genesis";
            Chapter = 3;
        }

    }
}