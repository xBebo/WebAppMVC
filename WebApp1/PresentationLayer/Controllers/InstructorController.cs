using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;

namespace WebApp1.PresentationLayer.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly IDepartmentService _departmentService;

        public InstructorController(
            IInstructorService instructorService,
            IDepartmentService departmentService)
        {
            _instructorService = instructorService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var instructors = _instructorService.GetAll();

            return View(instructors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.GetAll();

            ViewBag.Departments = new SelectList(
                departments,
                "Id",
                "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(AddInstructorView instructorView)
        {
            if (ModelState.IsValid)
            {
                var instructor = new Instructor
                {
                    Name = instructorView.Name,
                    Address = instructorView.Address,
                    Salary = instructorView.Salary,
                    DeptId = instructorView.DeptId
                };

                _instructorService.Add(instructor);

                return RedirectToAction("Index");
            }

            var departments = _departmentService.GetAll();

            ViewBag.Departments = new SelectList(
                departments,
                "Id",
                "Name");

            return View(instructorView);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var instructor = _instructorService.GetById(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _instructorService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}