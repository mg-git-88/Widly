using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widly.Models;
using Widly.ViewModels;

namespace Widly.Controllers
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
            return View();
        }


        public ActionResult Customers()
        {
            var custViewModel = new CustomerFormViewModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType)
            };

            return View(custViewModel);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(o => o.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel 
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            else
            {
                if (customer != null && customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.DOB = customer.DOB;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                }
                _context.SaveChanges();
                return RedirectToAction("Customers");
            }
        }

        public ActionResult EditCustomer(int id)
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c => c.Id == id),
                MembershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }
    }
}