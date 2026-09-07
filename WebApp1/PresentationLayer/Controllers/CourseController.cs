using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;

namespace WebApp1.PresentationLayer.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;

        public CourseController(
            ICourseService courseService,
            IDepartmentService departmentService,
            IInstructorService instructorService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
            _instructorService = instructorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var courses = _courseService.GetAll();

            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.GetAll();

            var instructors = _instructorService.GetAll();

            ViewBag.Departments = new SelectList(
                departments,
                "Id",
                "Name");

            ViewBag.Instructors = new SelectList(
                instructors,
                "Id",
                "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(AddCourseView courseView)
        {
            // ModelState checks [Required] and binding errors.
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Name = courseView.Name,
                    MinDegree = courseView.MinDegree,
                    DeptId = courseView.DeptId,
                    InstructorId = courseView.InstructorId
                };

                // Save through the service.
                _courseService.Add(course);

                return RedirectToAction("Index");
            }

            // If validation fails, refill the dropdowns.
            var departments = _departmentService.GetAll();
            var instructors = _instructorService.GetAll();

            ViewBag.Departments = new SelectList(
                departments,
                "Id",
                "Name");

            ViewBag.Instructors = new SelectList(
                instructors,
                "Id",
                "Name");

            return View(courseView);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _courseService.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}