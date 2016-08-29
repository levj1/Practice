using MvcApp.Models.JsonObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class ReadingModels
    {
        public Rootobject ApiJson { get; set; }
        public TodayReading TdayReading { get; set; }
    }


    public class TodayReading
    {
        public string BookName { get { return "John"; } }
        public string Chapter { get { return "4"; } }
        public string Verses { get { return "1-5"; } }
    }

}