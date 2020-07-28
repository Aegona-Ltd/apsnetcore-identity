using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models.Application;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    public class ApplicationController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;
        //private IEmployeeDepartmentRepository _employeeDepartmentRepository;

        public ApplicationController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
            //EmployeeDepartmentRepositoryImpl employeeDepartmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            //_employeeDepartmentRepository = employeeDepartmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
