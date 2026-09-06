using Microsoft.EntityFrameworkCore;
using WebApp1.DAL.Entities;

namespace WebApp1.DAL.Database
{
    public class AppDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=WebApp1Db;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite primary key for Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });


            // Department -> Instructors (One -> Many)
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department -> Manager (One-to-One / Zero-to-One)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "CS", Manager_HireDate = new DateOnly(2020, 1, 1) },
                new Department { Id = 2, Name = "OS", Manager_HireDate = new DateOnly(2019, 5, 1) }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Osama", Address = "Cairo", Salary = 15000, DeptId = 1 },
                new Instructor { Id = 2, Name = "Ahmed", Address = "Alexandria", Salary = 18000, DeptId = 2 },
                new Instructor { Id = 3, Name = "Mona", Address = "Mansoura", Salary = 12000, DeptId = 1 }
            );


            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "OOP", MinDegree = 60, DeptId = 1, InstructorId = 1 },
                new Course { Id = 2, Name = "OS", MinDegree = 50, DeptId = 2, InstructorId = 2 },
                new Course { Id = 3, Name = "DB", MinDegree = 55, DeptId = 1, InstructorId = 3 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Hamada", Address = "Cairo" },
                new Student { Id = 2, Name = "Hoda", Address = "Giza" },
                new Student { Id = 3, Name = "Sara", Address = "Alexandria" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { StudentId = 1, CourseId = 1, Grade = 85, Degree = "A" },
                new Enrollment { StudentId = 1, CourseId = 3, Grade = 78, Degree = "B" },
                new Enrollment { StudentId = 2, CourseId = 2, Grade = 92, Degree = "A+" }
            );
        }
    }
}
