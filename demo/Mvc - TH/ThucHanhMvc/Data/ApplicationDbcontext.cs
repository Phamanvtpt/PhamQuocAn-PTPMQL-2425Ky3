using Microsoft.EntityFrameworkCore;
using ThucHanhMvc.Models;

namespace ThucHanhMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext>options): base( options)
        {}
        public DbSet <Person> Person { get; set;}

    }
}
// 41