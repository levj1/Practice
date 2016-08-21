using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MvcApp.Models;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ReadingModels reading = new ReadingModels();

            using (var client = new HttpClient())
            {

                //string uriToken = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";
                //var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}", "jameslevj@gmail.com", "mamajames1226")));

                var uri = new Uri("https://bible-api.com/john 3:5");

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);


                var response = await client.GetAsync(uri);
                string textResult = await response.Content.ReadAsStringAsync();

                JObject joResponse = JObject.Parse(textResult);
                JArray array = (JArray)joResponse["verses"];

                reading.BookName = array[0].ToString();
                //reading.Chapter =  array[1].ToString();
                //reading.Text  =  array[2].ToString();

                foreach (var item in array)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            return View(reading);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}