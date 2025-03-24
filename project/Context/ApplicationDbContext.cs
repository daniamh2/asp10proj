using project.Models;
using Microsoft.EntityFrameworkCore;

namespace project.Context
{
    public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(b => b.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            
            });

        }
        public DbSet<Category> Categories { get; set; }
    }
}
