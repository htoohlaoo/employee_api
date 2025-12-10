using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmenttId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Head)
                .WithMany() // No navigation in Employee for Department head
                .HasForeignKey(d => d.HeadId)
                .OnDelete(DeleteBehavior.Restrict);
            // Prevent deleting employee → deleting entire department
        }
    }

}
