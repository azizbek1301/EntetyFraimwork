using EntetyEntery.Models;
using Microsoft.EntityFrameworkCore;

namespace EntetyEntery.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Students> Students {  get; set; } 
    }
}
