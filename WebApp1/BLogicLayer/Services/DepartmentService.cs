using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Department> GetAll()
        {
            return _context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Courses)
                .ToList();
        }

        public Department? GetById(int id)
        {
            return _context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Courses)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
