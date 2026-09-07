using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class AddCourseView
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int MinDegree { get; set; }

        [Required]
        public int DeptId { get; set; }

        [Required]
        public int InstructorId { get; set; }
    }
}