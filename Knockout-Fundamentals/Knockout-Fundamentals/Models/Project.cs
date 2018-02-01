using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Fundamentals.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public DateTime? DateReceived { get; set; }
        public string ShortName { get; set; }
        public string Issue { get; set; }
    }
}