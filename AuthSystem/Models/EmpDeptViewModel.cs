using AuthSystem.Models.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class EmpDeptViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Select employee(s)")]
        public List<SelectListItem> Employees{ get; set; }
        public List<Employee> Emps { get; set; }
        public Department Dept { get; set; }
        public int DeptId { get; set; }
        public List<int> EmpIds { get; set; }
    }
}
