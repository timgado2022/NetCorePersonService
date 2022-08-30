using Microsoft.EntityFrameworkCore;
using PersonService.Models;

namespace PersonService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}