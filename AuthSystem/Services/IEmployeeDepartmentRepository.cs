using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public interface IEmployeeDepartmentRepository
    {
        bool AddEmpDept(List<EmployeeDepartment> empDepts);
    }
}
