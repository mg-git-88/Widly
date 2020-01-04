using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Widly.Models;

namespace Widly.CustomAttributes
{
    public class AgeRestrictionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var customer = (Customer)context?.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.DOB == null)
            {
                return new ValidationResult("The Birth Date is required.");
            }

            var age = DateTime.Today.Year - customer.DOB.Value.Year;

            return (age >= MembershipType.AgeLimit) 
                ? ValidationResult.Success 
                : new ValidationResult("The Customer must be at least 18 years old to be able to subscribe.");
        }
    }
}