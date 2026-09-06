using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Services
{
    public class EnrollmentService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Enrollment> GetAll()
        {
            return _context.Enrollments.ToList();
        }
    }
}