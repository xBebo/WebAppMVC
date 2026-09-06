using Microsoft.AspNetCore.Mvc;
using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;
namespace WebApp1.PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext Db = new AppDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            var students = Db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        [Route("Students/details")]
        public IActionResult Details(int id)
        {
            var student = Db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
