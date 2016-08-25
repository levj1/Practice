using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApiDemo.Controllers
{

    public class ValuesController : ApiController
    {
        static List<string> names = new List<string>();
        // GET api/values
        public IEnumerable<string> Get()
        {
            string path = @"C:\Users\James Leveille\Documents\GitHub\Practice\MvcApiDemo\MvcApiDemo\names.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    names.Add(line);
                }
            }
            return names;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return names[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            names.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            names[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            names.RemoveAt(id);
        }
    }
}
