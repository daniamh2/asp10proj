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
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);

                entity.Property(p => p.Description)
                .HasColumnType("varchar(max)");

                entity.Property(p => p.Price)
                .HasColumnType("decimal(6,2)");

            }); 
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(b => b.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            
            });

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
