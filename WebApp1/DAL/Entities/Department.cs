namespace WebApp1.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ManagerId { get; set; }
        public DateOnly? Manager_HireDate { get; set; }

        
        public Instructor? Manager { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
    }   
}
