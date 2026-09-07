using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Interfaces
{
    public interface IEnrollmentService
    {
        List<EnrollmentViewModel> GetAll();

        Enrollment? GetById(int studentId, int courseId);

        void Add(Enrollment enrollment);

        void Delete(int studentId, int courseId);
    }
}