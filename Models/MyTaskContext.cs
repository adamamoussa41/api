
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Crud_api.Models
{
    public class MyTaskContext : DbContext
    {
        public MyTaskContext(DbContextOptions<MyTaskContext> options)
            : base(options)
        {
        }

        public DbSet<MyTask> MyTasks { get; set; } = null!;
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<MyTask>()
        //         .HasOne(t => t.Material);
        // }
    }
}