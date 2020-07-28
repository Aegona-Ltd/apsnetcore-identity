using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public class EmployeeRepositoryImpl : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public List<Employee> GetEmpsByDept(int Id)
        {
            List<int> a = context.EmployeeDepartments.Where(x => x.DepartmentId == Id).Select(y => y.EmployeeId).ToList();
            List<Employee> employees = new List<Employee>();
            foreach (var item in a)
            {
                employees.Add(context.Employees.Where(e => e.Id == item).Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Address = e.Address,
                    Gender = e.Gender,
                    EmpCode = e.EmpCode,
                    //DeleteStatus = !context.EmployeeDepartments.Any(ed => ed.EmployeeId == e.Id)

                }).FirstOrDefault());
            }
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
