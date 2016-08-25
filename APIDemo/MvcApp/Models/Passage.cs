using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class Passage
    {
        public string display { get; set; }
        public string version { get; set; }
        public string version_abbreviation { get; set; }
        public string path { get; set; }
        public string start_verse_id { get; set; }
        public string end_verse_id { get; set; }
        public string text { get; set; }
        public string copyright { get; set; }
    }
}