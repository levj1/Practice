using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF.WebMVC.Models
{
    public class Address
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}