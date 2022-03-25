using StudentRegistrationWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistrationWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Student> FormData { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<Models.Stream> Stream { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employee { get; set; }




    }
}
