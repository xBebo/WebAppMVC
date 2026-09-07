using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        // ASP.NET gives the service its DbContext.
        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        public List<CourseViewModel> GetAll()
        {
            return _context.Courses
            .Select(c => new CourseViewModel
            {
                Id = c.Id,
                Name = c.Name,
                MinDegree = c.MinDegree,

                DepartmentName = c.Department != null
                    ? c.Department.Name
                    : null,

                InstructorName = c.Instructor != null
                    ? c.Instructor.Name
                    : null
            })
                .ToList();
        }

        public List<CourseViewModel> GetByDeptId(int deptId)
        {
            return _context.Courses
                .Where(c => c.DeptId == deptId)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    MinDegree = c.MinDegree
                })
                .ToList();
        }

        public CourseViewModel? GetById(int id)
        {
            return _context.Courses
                .Where(c => c.Id == id)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    MinDegree = c.MinDegree,

                    DepartmentName = c.Department != null
                        ? c.Department.Name
                        : null,

                    InstructorName = c.Instructor != null
                        ? c.Instructor.Name
                        : null
                })
                .FirstOrDefault();
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}