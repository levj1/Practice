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

namespace MvcApp.Controllers
{
  
    public class ReadingJsonController : Controller
    {
       
        //static string address = "https://bibles.org/v2/passages.js?q[]=john+3:1-5&version=eng-KJVA/";
        static string address = @"https://bibles.org/v2/eng-KJVA/passages.js?q[]=john+3%3A1-5";
        static string ApiToken = GetAppSetting("token");
        static string ApiPassword = GetAppSetting("apiPassword");

        // GET: ReadingJson
        public async Task<ActionResult> Index()
        {
            Rootobject rootObj = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", ApiToken, ApiPassword)));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                HttpResponseMessage response = await client.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    rootObj = JsonConvert.DeserializeObject<Rootobject>(result);
                }

                return View(rootObj);
            }

        }

        public static string GetAppSetting(string appSetting)
        {
            return System.Configuration.ConfigurationManager.AppSettings[appSetting];
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
