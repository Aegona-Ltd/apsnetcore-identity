using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public class EmployeeDepartmentRepositoryImpl : IEmployeeDepartmentRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeDepartmentRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
        }
        public EmployeeDepartment Add(EmployeeDepartment employeeDepartment)
        {
            context.EmployeeDepartments.Add(employeeDepartment);
            context.SaveChanges();
            return employeeDepartment;
        }

        public EmployeeDepartment Delete(int Id)
        {
            EmployeeDepartment employeeDepartment = context.EmployeeDepartments.Find(Id);
            if (employeeDepartment != null)
            {
                context.EmployeeDepartments.Remove(employeeDepartment);
                context.SaveChanges();
            }
            return employeeDepartment;
        }

        public IEnumerable<EmployeeDepartment> GetAllEmployeeDepartment()
        {
            return context.EmployeeDepartments;
        }

        public EmployeeDepartment GetEmployeeDepartment(int Id)
        {
            return context.EmployeeDepartments.Find(Id);
        }

        public EmployeeDepartment Update(EmployeeDepartment employeeDepartmentChanges)
        {
            var employeeDepartment = context.EmployeeDepartments.Attach(employeeDepartmentChanges);
            employeeDepartment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeDepartmentChanges;
        }
    }
}
