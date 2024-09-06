using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using StudentAndCourseCrudNHibernateDemo.Data;
using StudentAndCourseCrudNHibernateDemo.Models;

namespace StudentAndCourseCrudNHibernateDemo.Validations
{
    public class NameValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                Regex regex = new Regex(@"^[a-zA-Z\s]+$");
                if (regex.IsMatch(name))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name should only contain alphabets and spaces, without any special characters or numbers.");
        }

    }
}