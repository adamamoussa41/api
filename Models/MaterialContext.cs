
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Crud_api.Models
{
    public class MaterialContext : DbContext
    {
        public MaterialContext(DbContextOptions<MaterialContext> options)
            : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; } = null!;
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Material>()
        //         .HasMany(m => m.MyTasks);
        // }
    }
}