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
        public EmployeeDepartment AddEmployeeDepartment(EmployeeDepartment empDept)
        {
            context.EmployeeDepartments.Add(empDept);
            context.SaveChanges();
            return empDept;
        }

        public void Delete(EmployeeDepartment empDept)
        {
            context.EmployeeDepartments.Remove(empDept);
            context.SaveChanges();
        }

        public List<EmployeeDepartment> FindEmpsByDeptId(int Id)
        {
            List<EmployeeDepartment> a = context.EmployeeDepartments.Where(x => x.DepartmentId == Id).ToList();
            return a;
        }
    }
}
