using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Widly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The Release Date field is required.")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "The Number In Stock field is required.")]
        [Range(1, 20, ErrorMessage = "Stock should be between 1 and 20.")]
        public short NumberInStock { get; set; }

        [Required(ErrorMessage = "The Genre field is required.")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}