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
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        // ASP.NET gives the service its DbContext.
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }
        public List<DepartmentListViewModel> GetAll()
        {
            return _context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Courses)
                .Select(d => new DepartmentListViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ManagerName = d.Manager != null
                        ? d.Manager.Name
                        : null,
                    ManagerHireDate = d.Manager_HireDate,
                    CoursesCount = d.Courses != null
                        ? d.Courses.Count
                        : 0
                })
                .ToList();
        }

        public DepartmentDetailsViewModel? GetById(int id)
        {
            return _context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Courses)
                .Where(d => d.Id == id)
                .Select(d => new DepartmentDetailsViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ManagerName = d.Manager != null
                        ? d.Manager.Name
                        : null,
                    ManagerHireDate = d.Manager_HireDate,

                    Courses = d.Courses == null
                        ? new List<CourseViewModel>()
                        : d.Courses.Select(c => new CourseViewModel
                        {
                            Id = c.Id,
                            Name = c.Name,
                            MinDegree = c.MinDegree
                        }).ToList()
                })
                .FirstOrDefault();
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public bool IsManagerUsed(int instructorId)
        {
            // True if any Department already uses this Instructor as Manager.
            return _context.Departments
                .Any(d => d.ManagerId == instructorId);
        }
    }
}
