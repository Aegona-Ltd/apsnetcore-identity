using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public interface IEmployeeDepartmentRepository
    {
        EmployeeDepartment GetEmployeeDepartment(int Id);
        IEnumerable<EmployeeDepartment> GetAllEmployeeDepartment();
        EmployeeDepartment Add(EmployeeDepartment employeeDepartment);
        EmployeeDepartment Update(EmployeeDepartment employeeDepartmentChanges);
        EmployeeDepartment Delete(int Id);
    }
}
