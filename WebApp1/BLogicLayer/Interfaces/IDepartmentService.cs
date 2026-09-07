using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp1.BLogicLayer.Interfaces
{
    public interface IDepartmentService
    {
        List<DepartmentListViewModel> GetAll();

        DepartmentDetailsViewModel? GetById(int id);

        void Add(Department department);

        void Delete(int id);

        // Used by custom validation.
        bool IsManagerUsed(int instructorId);
    }
}