using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class AddEnrollmentView
    {
        // Which student is enrolling.
        [Required]
        public int StudentId { get; set; }

        // Which course they're enrolling in.
        [Required]
        public int CourseId { get; set; }

        // Numeric grade
        [Required]
        public int Grade { get; set; }

        // Letter grade
        [Required]
        public string? Degree { get; set; }
    }
}
