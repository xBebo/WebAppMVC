using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Services
{
    public class CourseService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public List<Course> GetByDeptId(int deptId)
        {
            return _context.Courses
                .Where(c => c.DeptId == deptId)
                .ToList();
        }
    }
}