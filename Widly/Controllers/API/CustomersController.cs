using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Widly.DTOs;
using Widly.Models;

namespace Widly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/Customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(AutoMapperConfig<Customer, CustomerDTO>.MapModels));
        }

        // GET api/Customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(AutoMapperConfig<Customer, CustomerDTO>.MapModels(customer));
        }

        // POST api/Customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            Customer customer = null;
            if (!ModelState.IsValid)
                return BadRequest();
            if (customerDto != null)
            {
                customer = AutoMapperConfig<CustomerDTO, Customer>.MapModels(customerDto);

                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;
            }
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT api/Customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            if (customerDto != null)
            {
                AutoMapperConfig<CustomerDTO, Customer>.MapModels(customerDto);
            }
            _context.SaveChanges();
        }

        // DELETE api/Customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
