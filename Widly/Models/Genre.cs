﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Widly.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}