using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public interface IEmployeeDepartmentRepository
    {
        EmployeeDepartment AddEmployeeDepartment(EmployeeDepartment empDept);
        bool AddEmpDept(List<EmployeeDepartment> empDepts);
        void Delete(EmployeeDepartment empDept);
        List<EmployeeDepartment> FindEmpsByDeptId(int Id);
    }
}
