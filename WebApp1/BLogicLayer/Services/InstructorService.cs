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
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;

        // ASP.NET gives the service its DbContext.
        public InstructorService(AppDbContext context)
        {
            _context = context;
        }
        public List<InstructorViewModel> GetByDeptId(int deptId)
        {
            return _context.Instructors
                .Where(i => i.DeptId == deptId)
                .Select(i => new InstructorViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary
                })
                .ToList();
        }

        public List<InstructorViewModel> GetAll()
        {
            return _context.Instructors
                .Select(i => new InstructorViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary
                })
                .ToList();
        }

        public InstructorViewModel? GetById(int id)
        {
            return _context.Instructors
                .Where(i => i.Id == id)
                .Select(i => new InstructorViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary
                })
                .FirstOrDefault();
        }
        public void Add(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);

            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }
    }
}
