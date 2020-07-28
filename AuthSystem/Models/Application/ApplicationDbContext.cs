using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Seed data
            builder.Entity<EmployeeDepartment>().HasKey(table => new
            {
                table.EmployeeId,
                table.DepartmentId
            });
            builder.Entity<EmployeeDepartment>()
                .HasOne(e => e.Employee)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(e => e.EmployeeId);
            builder.Entity<EmployeeDepartment>()
                .HasOne(d => d.Department)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
