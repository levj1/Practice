using Knockout_Fundamentals.Models;
using Knockout_Fundamentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Knockout_Fundamentals.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context; 
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_context.Customers.ToList());
        }



        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Id = customer.Id;
            customerViewModel.Name = customer.Name;
            customerViewModel.Age = customer.Age;
            customerViewModel.Comments = customer.Comments;
            customerViewModel.MessageToClient = "I Originated from the viewmodel";

            return View(customerViewModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
