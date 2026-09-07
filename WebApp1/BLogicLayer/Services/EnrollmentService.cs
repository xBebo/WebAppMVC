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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public List<EnrollmentViewModel> GetAll()
        {
            return _context.Enrollments

                // Load related Student.
                .Include(e => e.Student)

                // Load related Course.
                .Include(e => e.Course)

                // Convert DB entity into data for the View.
                .Select(e => new EnrollmentViewModel
                {
                    StudentId = e.StudentId,
                    StudentName = e.Student != null
                        ? e.Student.Name
                        : null,

                    CourseId = e.CourseId,
                    CourseName = e.Course != null
                        ? e.Course.Name
                        : null,

                    Grade = e.Grade,
                    Degree = e.Degree
                })

                .ToList();
        }

        public Enrollment? GetById(int studentId, int courseId)
        {
            return _context.Enrollments.Find(studentId, courseId);
        }

        public void Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public void Delete(int studentId, int courseId)
        {
            var enrollment =
                _context.Enrollments.Find(studentId, courseId);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }
        }
    }
}