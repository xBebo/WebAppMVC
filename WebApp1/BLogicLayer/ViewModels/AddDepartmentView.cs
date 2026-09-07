using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using WebApp1.BLogicLayer.ValidationAttributes;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class AddDepartmentView
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [NotUsedManager]
        public int ManagerId { get; set; }

        [Required]
        public DateOnly? ManagerHireDate { get; set; }
    }
}