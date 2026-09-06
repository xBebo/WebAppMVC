using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.DAL.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MinDegree { get; set; }

        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department? Department { get; set; }

        public int? InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public Instructor? Instructor { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }

    }
}
