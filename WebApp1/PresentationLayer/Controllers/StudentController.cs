using Microsoft.AspNetCore.Mvc;
using WebApp1.BLogicLayer.Services;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;
namespace WebApp1.PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService = new StudentService();

        [HttpGet]
        public IActionResult Index()
        {
            var students = _studentService.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
