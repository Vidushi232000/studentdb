using Microsoft.EntityFrameworkCore;
using studentdb.Model;



namespace studentdb.Data
{
    public class StudentContext : DbContext 

    {
        public DbSet<Student> Students { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

    }
}
