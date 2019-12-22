using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widly.Models;
using Widly.ViewModels;

namespace Widly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Customers()
        {
            var custViewModel = new RandomMovieViewModel
            {
                Customers = GetCustomers()
            };
            return View(custViewModel);
        }

        public ActionResult CustomerDetails(int id)
        {
            var cust = new Customer
            {
                Name = GetCustomers().Single(o => o.Id == id).Name
            };
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer> {
                new Customer {Id=1, Name="Mayukh"},
                new Customer {Id=2, Name="Manoj"},
                new Customer {Id=3, Name="Akanksha"},
                new Customer {Id=4, Name="Hemanth"},
                new Customer {Id=5, Name="Subhankar"}
        };
            return customers;
        }
    }
}