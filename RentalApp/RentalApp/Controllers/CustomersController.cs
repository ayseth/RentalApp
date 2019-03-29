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
                Customer = new Customer(),
                MembershipType = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) //called Model binding
        {
            // model state property to get access to validation data
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer, //reqiured to populate the form with values user has put in the form
                    MembershipType = _context.MembershipType.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)   //for a new customer
                _context.Customers.Add(customer);     //similar to  db.session.add in python
            else                    //for existing customer
            {
                //first get from DB, so dbcontext can track changes and then modify property & save
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);  //used single
                                                                                         //instead of singleordefult so
                                                                                         //if the customer is not found,
                                                                                         //and exception will occur 
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                  }
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