using MvcApp.Models;
using MvcApp.Models.JsonObject;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using static MvcApp.Models.JsonObject.Rootobject;

namespace MvcApp.Controllers
{
    public class ReadingJsonController : Controller
    {
        static string _address = @"https://bibles.org/v2/eng-KJVA/passages.js?q[]=john+3%3A1-5";
        static string _password = "mamajames1226";
        static string _token = "hCqGoQYlBorqkIyQnjpMSlqzx1Q1YEAUZaJMCrXN";
        
        // GET: ReadingJson
        public async Task<ActionResult> Index()
        {
            Rootobject rootobj = null;

            using (var client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _token, _password));
                var header = new AuthenticationHeaderValue(
                           "Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Authorization = header;

                var result = await client.GetAsync(_address);
                string textResult = await result.Content.ReadAsStringAsync();
                rootobj = JsonConvert.DeserializeObject<Rootobject>(textResult);
                
                return View(rootobj);
            }
        }

        // GET: ReadingJson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReadingJson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReadingJson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadingJson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReadingJson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadingJson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReadingJson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
