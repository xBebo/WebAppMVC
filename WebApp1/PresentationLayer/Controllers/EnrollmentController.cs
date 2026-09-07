using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp1.BLogicLayer.Interfaces;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;

namespace WebApp1.PresentationLayer.Controllers
{
    public class EnrollmentController : Controller
    {
        // → save/list enrollments
        private readonly IEnrollmentService _enrollmentService;
        // → Student dropdown
        private readonly IStudentService _studentService;
        // → Course dropdown
        private readonly ICourseService _courseService;

        public EnrollmentController(
            IEnrollmentService enrollmentService,
            IStudentService studentService,
            ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Read all enrollment rows.
            var enrollments = _enrollmentService.GetAll();

            return View(enrollments);
        }

        [HttpGet]
        public IActionResult Create(int? courseId)
        {
            var students = _studentService.GetAll();
            var courses = _courseService.GetAll();

            ViewBag.Students = new SelectList(
                students,
                "Id",
                "Name");

            ViewBag.Courses = new SelectList(
                courses,
                "Id",
                "Name",
                courseId);

            var model = new AddEnrollmentView();

            if (courseId.HasValue)
            {
                model.CourseId = courseId.Value;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AddEnrollmentView enrollmentView)
        {
            if (ModelState.IsValid)
            {
                var enrollment = new Enrollment
                {
                    StudentId = enrollmentView.StudentId,
                    CourseId = enrollmentView.CourseId,
                    Grade = enrollmentView.Grade,
                    Degree = enrollmentView.Degree
                };

                _enrollmentService.Add(enrollment);

                return RedirectToAction("Index");
            }

            // Validation failed, so refill dropdowns.
            var students = _studentService.GetAll();
            var courses = _courseService.GetAll();

            ViewBag.Students = new SelectList(
                students,
                "Id",
                "Name");

            ViewBag.Courses = new SelectList(
                courses,
                "Id",
                "Name");

            return View(enrollmentView);
        }

        [HttpGet]
        public IActionResult Delete(int studentId, int courseId)
        {
            var enrollment =
                _enrollmentService.GetById(studentId, courseId);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(
            int studentId,
            int courseId)
        {
            _enrollmentService.Delete(studentId, courseId);

            return RedirectToAction("Index");
        }
    }
}