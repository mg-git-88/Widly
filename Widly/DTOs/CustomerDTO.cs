using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Widly.CustomAttributes;
using Widly.Models;

namespace Widly.DTOs
{
    [AutoMap(typeof(Customer))]
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[AgeRestriction]
        public DateTime? DOB { get; set; }
    }
}