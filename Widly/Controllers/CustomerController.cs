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
            var custViewModel = new RandomMovieViewModel();
            return View(custViewModel);
        }

        public ActionResult CustomerDetails(int id)
        {
            var custViewModel = new RandomMovieViewModel();
            Customer cust = new Customer();
            cust.Name = custViewModel.Customers.Find(o => o.Id == id).Name;
            return View(cust);
        }
    }
}