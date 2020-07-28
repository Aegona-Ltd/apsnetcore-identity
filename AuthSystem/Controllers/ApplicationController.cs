using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using AuthSystem.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeDepartmentRepository _employeeDepartmentRepository;

        public ApplicationController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IEmployeeDepartmentRepository employeeDepartmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _employeeDepartmentRepository = employeeDepartmentRepository;
        }
        //Employee
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployee());
        }
        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            _employeeRepository.Add(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EmployeeEdit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EmployeeEdit(Employee employeeChanges)
        {
            _employeeRepository.Update(employeeChanges);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EmployeeDelete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //Department
        public IActionResult DepartmentList()
        {
            return View(_departmentRepository.GetAllDepartment());
        }

        [HttpGet]
        public IActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmentAdd(Department department)
        {
            _departmentRepository.Add(department);
            return RedirectToAction("DepartmentList");
        }
        [HttpGet]
        public IActionResult DepartmentEdit(int id)
        {
            Department department = _departmentRepository.GetDepartment(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult DepartmentEdit(Department departmentChanges)
        {
            _departmentRepository.Update(departmentChanges);
            return RedirectToAction("DepartmentList");
        }

        [HttpGet]
        public IActionResult DepartmentDelete(int id)
        {
            _departmentRepository.Delete(id);
            return RedirectToAction("DepartmentList");
        }
        //Edit emps in dept
        [HttpGet]
        public IActionResult EditEmpToDept(int id)
        {
            var a = _employeeRepository.GetEmpsByDept(id).Select(x => x.Name).ToList();
            ViewBag.a = a;
            var e = _employeeRepository.GetAllEmployee().Select(x => x.Id).ToList();
            var employees = _employeeRepository.GetAllEmployee().Select(
                x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            var dept = _departmentRepository.GetDepartment(id);
            var empDept = new EmpDeptViewModel
            {
                DeptId = dept.Id,
                Name = dept.Name,
                Employees = employees,
                EmpIds = e
            };
            return View(empDept);
        }
        [HttpPost]
        public IActionResult EditEmpToDept(List<int> Employees, int DeptId)
        {
            List<EmployeeDepartment> employeeDepartments = new List<EmployeeDepartment>();
            foreach (var item in Employees)
            {
                employeeDepartments.Add(new EmployeeDepartment
                {
                    EmployeeId = item,
                    DepartmentId = DeptId
                });
            }
            _ = _employeeDepartmentRepository.AddEmpDept(employeeDepartments);
            return RedirectToAction("DepartmentList");
        }
    }
}
