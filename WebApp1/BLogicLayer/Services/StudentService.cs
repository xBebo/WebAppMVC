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
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        // ASP.NET gives the service its DbContext.
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentViewModel> GetAll()
        {
            return _context.Students
                .Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address
                })
                .ToList();
        }

        public StudentViewModel? GetById(int id)
        {
            return _context.Students
                .Where(s => s.Id == id)
                .Select(s => new StudentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address
                })
                .FirstOrDefault();
        }

        public void Add(Student student)
        {
            // Add the new row to Students.
            _context.Students.Add(student);

            // Save it to SQL Server.
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Search by primary key.
            var student = _context.Students.Find(id);

            // Only delete if it exists.
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

    }
}
