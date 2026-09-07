using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp1.BLogicLayer.Interfaces
{
    public interface ICourseService
    {
        List<CourseViewModel> GetAll();

        CourseViewModel? GetById(int id);

        List<CourseViewModel> GetByDeptId(int deptId);

        void Add(Course course);

        void Delete(int id);
    }
}