using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using WebApp1.BLogicLayer.Interfaces;

namespace WebApp1.BLogicLayer.ValidationAttributes
{
    public class NotUsedManager : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            // Nothing to validate if no value was supplied.
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // Ask the DI container for IDepartmentService.
            var departmentService =
                validationContext
                    .GetService<IDepartmentService>();

            if (departmentService == null)
            {
                return ValidationResult.Success;
            }

            var instructorId = (int)value;

            // Check the database through the service.
            if (departmentService.IsManagerUsed(instructorId))
            {
                return new ValidationResult(
                    "This instructor already manages a department.");
            }

            return ValidationResult.Success;
        }
    }
}