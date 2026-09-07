using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApp1.PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _deptService;
        private readonly IInstructorService _instService;

        public DepartmentController(

            IDepartmentService deptService,
            IInstructorService instService)
        {
            _deptService = deptService;
            _instService = instService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _deptService.GetAll();

            return View(departments);
        }

        // GET: /Department/Instructors/{id}
        [HttpGet]
        public IActionResult Instructors(int id)
        {
            var instructors = _instService.GetByDeptId(id);

            return View("Instructors", instructors);
        }

        // GET: /Department/Details/{id}
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _deptService.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View("Details", department);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            // Get instructors to show inside the Manager dropdown.
            var instructors = _instService.GetAll();

            ViewBag.Instructors = new SelectList(
                instructors,
                "Id",
                "Name");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(AddDepartmentView departmentView)
        {
            // Only save when model binding + validation succeeded.
            if (ModelState.IsValid)
            {
                // Convert the form ViewModel into the database entity.
                var department = new Department
                {
                    Name = departmentView.Name,
                    ManagerId = departmentView.ManagerId,
                    Manager_HireDate = departmentView.ManagerHireDate
                };

                _deptService.Add(department);

                return RedirectToAction("Index");
            }

            // If validation failed, rebuild the dropdown.
            var instructors = _instService.GetAll();

            ViewBag.Instructors = new SelectList(
                instructors,
                "Id",
                "Name");

            return View(departmentView);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _deptService.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _deptService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
