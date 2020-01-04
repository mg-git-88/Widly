﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Widly.CustomAttributes;

namespace Widly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "The Membership Type field is required.")]
        public byte MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        [AgeRestriction]
        public DateTime? DOB { get; set; }
    }
}