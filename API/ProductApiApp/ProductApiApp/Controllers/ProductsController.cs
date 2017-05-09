using ProductApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProductApiApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { ID = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { ID = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { ID = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public List<Product> GetProducts()
        {
            return products.ToList();
        }

        public IHttpActionResult GetProduct(int? id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
