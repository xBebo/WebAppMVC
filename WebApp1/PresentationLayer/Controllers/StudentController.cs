using Microsoft.AspNetCore.Mvc;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.Services;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;

namespace WebApp1.PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddStudentView studentView)
        {
            // Validation rules are checked after Model Binding.
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = studentView.Name,
                    Address = studentView.Address
                };

                // BLL saves it.
                _studentService.Add(student);

                return RedirectToAction("Index");
            }

            // Invalid form: show the same page with errors.
            return View(studentView);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the student that the user wants to delete.
            var student = _studentService.GetById(id);

            // If the Id doesn't exist, return 404.
            if (student == null)
            {
                return NotFound();
            }

            // Show the confirmation page.
            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Ask the service to remove the student.
            _studentService.Delete(id);

            // After deleting, go back to the Student list.
            return RedirectToAction("Index");
        }

    }
}
