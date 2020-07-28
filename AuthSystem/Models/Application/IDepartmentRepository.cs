using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int Id);
        IEnumerable<Department> GetAllDepartment();
        Department Add(Department department);
        Department Update(Department departmentChanges);
        void Delete(int Id);
    }
}
