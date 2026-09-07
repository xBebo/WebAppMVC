using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp1.BLogicLayer.ViewModels
{
    public class DepartmentListViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ManagerName { get; set; }

        public DateOnly? ManagerHireDate { get; set; }

        public int CoursesCount { get; set; }
    }
}
