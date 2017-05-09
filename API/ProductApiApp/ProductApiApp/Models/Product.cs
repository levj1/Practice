﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApiApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}