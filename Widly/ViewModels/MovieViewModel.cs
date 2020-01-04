using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}