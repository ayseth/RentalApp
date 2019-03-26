using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalApp.Models;
using RentalApp.ViewModels;

namespace RentalApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) //called Model binding
        {
            _context.Customers.Add(customer);  //similar to  db.session.add in python
            _context.SaveChanges();            // similar to  db.session.commit() in python

            return RedirectToAction("Index", "Customers"); //redirect to page
        }
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();   //<--Db set defined in db context

            return View(customers);
        }

        public ActionResult Details(int id)
        {
      //      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);  //query will be immidiately executed
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);


            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            return View("CustomerForm", viewModel);  //without this, MVC will look for 'Edit' view
        }
    }
}