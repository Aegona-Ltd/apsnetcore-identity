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

        public bool AddEmpDept(List<EmployeeDepartment> empDepts)
        {
            foreach (var item in empDepts)
            {
                context.EmployeeDepartments.Add(item);
                context.SaveChanges();
            }
            return true;
        }

        public bool EditEmpDept(List<EmployeeDepartment> empDeptsChange)
        {
            foreach (var item in empDeptsChange)
            {
                var a = context.EmployeeDepartments.Attach(item);
                a.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }
    }
}
