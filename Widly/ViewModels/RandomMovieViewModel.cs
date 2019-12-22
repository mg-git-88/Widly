using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movies { get; set; } = new List<Movie>
            {
                new Movie {Id=1, Name="Shrek"},
                new Movie {Id=2, Name="Wall-E"},
                new Movie {Id=3, Name="Spiderman"},
                new Movie {Id=4, Name="Inception"}
            };
        public List<Customer> Customers { get; set; } = new List<Customer> {
                new Customer {Id=1, Name="Mayukh"},
                new Customer {Id=2, Name="Manoj"},
                new Customer {Id=3, Name="Akanksha"},
                new Customer {Id=4, Name="Hemanth"},
                new Customer {Id=5, Name="Subhankar"}
        };
    }
}