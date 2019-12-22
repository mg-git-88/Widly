using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.ViewModels
{
    public class RandomMovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}