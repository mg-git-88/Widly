﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}