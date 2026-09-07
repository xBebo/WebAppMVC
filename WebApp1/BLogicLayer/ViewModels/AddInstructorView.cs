using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class AddInstructorView
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int DeptId { get; set; }
    }
}
