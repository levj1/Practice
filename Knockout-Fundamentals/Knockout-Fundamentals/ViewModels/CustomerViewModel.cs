using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Fundamentals.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Comments { get; set; }
        public string MessageToClient { get; set; }
    }
}