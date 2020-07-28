using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public class DepartmentRepositoryImpl : IDepartmentRepository
    {
        private readonly ApplicationDbContext context;

        public DepartmentRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Department Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return department;
        }

        public Department Delete(int Id)
        {
            Department department = context.Departments.Find(Id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
            return department;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return context.Departments;
        }

        public Department GetDepartment(int Id)
        {
            return context.Departments.Find(Id);
        }

        public Department Update(Department departmentChanges)
        {
            var department = context.Departments.Attach(departmentChanges);
            department.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return departmentChanges;
        }
    }
}
