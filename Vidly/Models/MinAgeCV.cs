using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MinAgeCV:ValidationAttribute
    {
        private readonly byte MinAge = 18;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthdate is a required field");

            var age = DateTime.Now.Year - customer.Birthday.Value.Year;
            return (age >= MinAge) ? ValidationResult.Success : new ValidationResult("Customer needs to be older than 18 years for this membership");
            
        }
    }
}