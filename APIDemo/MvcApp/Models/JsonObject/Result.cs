using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.JsonObject
{
    public class Result
    {
        public string type { get; set; }
        public Passage[] passages { get; set; }
    }
}