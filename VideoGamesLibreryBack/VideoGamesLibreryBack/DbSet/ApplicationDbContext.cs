using Microsoft.EntityFrameworkCore;
using VideoGamesLibreryBack.ModelDB;

namespace VideoGamesLibreryBack.DbSet
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>()
                .HasNoKey(); // Configura la entidad como sin clave
        }

        public DbSet<Games> Games { get; set; }
    }
}
