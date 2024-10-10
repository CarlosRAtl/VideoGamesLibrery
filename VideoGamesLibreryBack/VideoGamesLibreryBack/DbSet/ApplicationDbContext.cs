using Microsoft.EntityFrameworkCore;
using VideoGamesLibreryBack.ModelDB;

namespace VideoGamesLibreryBack.DbSet
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Games> Games { get; set; }
    }
}
