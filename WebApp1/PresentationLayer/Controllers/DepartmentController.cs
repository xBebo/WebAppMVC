using Microsoft.AspNetCore.Mvc;
using WebApp1.BLogicLayer.Services;
namespace WebApp1.PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _deptService = new DepartmentService();
        private readonly InstructorService _instService = new InstructorService();

        // GET: /Department
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
            ViewBag.DeptId = id;
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
    }
}
