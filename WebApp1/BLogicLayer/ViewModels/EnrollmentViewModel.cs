using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class EnrollmentViewModel
    {
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public int CourseId { get; set; }

        public string? CourseName { get; set; }

        public int Grade { get; set; }

        public string? Degree { get; set; }
    }
}