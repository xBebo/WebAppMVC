using WebApp1.DAL.Database;
using WebApp1.DAL.Entities;
namespace WebApp1.BLogicLayer.Services
{
    public class InstructorService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<Instructor> GetByDeptId(int deptId)
        {
            return _context.Instructors
                .Where(i => i.DeptId == deptId)
                .ToList();
        }
    }
}
