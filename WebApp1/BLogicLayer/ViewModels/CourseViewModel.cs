using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int MinDegree { get; set; }

        public string? DepartmentName { get; set; }

        public string? InstructorName { get; set; }
    }
}