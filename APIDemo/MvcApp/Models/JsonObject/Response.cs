using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.JsonObject
{
    public class Response
    {
        public Search search { get; set; }
        public Meta meta { get; set; }
    }
}