using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetById(int id)
        {
            return _context.Students
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
