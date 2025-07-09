using Microsoft.EntityFrameworkCore;
using Demo.Models;
namespace Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}