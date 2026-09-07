using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp1.BLogicLayer.Interfaces
{
    public interface IInstructorService
    {
        // List all
        List<InstructorViewModel> GetAll();

        // Find one 
        InstructorViewModel? GetById(int id);

        List<InstructorViewModel> GetByDeptId(int deptId);

        void Add(Instructor instructor);

        void Delete(int id);
    }
}