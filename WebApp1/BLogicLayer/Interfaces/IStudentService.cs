using System;
using System.Collections.Generic;
using System.Text;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;

namespace WebApp1.BLogicLayer.Interfaces
{
    public interface IStudentService
    {
        // Read all
        List<StudentViewModel> GetAll();
        StudentViewModel? GetById(int id);
        void Add(Student student);
        void Delete(int id);
    }
}