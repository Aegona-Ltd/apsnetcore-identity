using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public class EmployeeDepartment
    {
        [Key]
        public int EmployeeId { get; set; }
        [Key]
        public int DepartmentId { get; set; }
    }
}
