
using Microsoft.EntityFrameworkCore;
namespace BookCatalogService.Model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasPrecision(5, 2); // ✅ same as decimal(18,2)
            modelBuilder.Entity<Book>()
            .Property(b => b.Rating)
            .HasPrecision(5, 2); // ✅ same as decimal(18,2)

        base.OnModelCreating(modelBuilder);
    }

}
