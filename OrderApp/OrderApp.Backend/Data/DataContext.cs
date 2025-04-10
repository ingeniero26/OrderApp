using Microsoft.EntityFrameworkCore;
using OrderApp.Shared.Entities;

namespace OrderApp.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       // public DbSet<BranchType> BranchTypes { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
    }
    
}
