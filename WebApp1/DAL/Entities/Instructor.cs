namespace WebApp1.DAL.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        
        public int? DeptId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
