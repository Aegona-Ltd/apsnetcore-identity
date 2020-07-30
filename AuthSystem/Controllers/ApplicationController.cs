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
    [Authorize(Roles = "Admin, UserList")]
    public class ApplicationController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeDepartmentRepository _employeeDepartmentRepository;

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
            var employees = _employeeRepository.GetAllEmployee();
            return View(employees);
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
            var departments = _departmentRepository.GetAllDepartment();
            return View(departments);
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
            List<EmployeeDepartment> empDepts = _employeeDepartmentRepository.FindEmpsByDeptId(DeptId);
            //Delete
            if (empDepts != null)
            {
                foreach (var empDept in empDepts)
                {
                    _employeeDepartmentRepository.Delete(empDept);
                }
            }
            //Add 
            foreach (var item in Employees)
            {
                EmployeeDepartment employeeDepartment = new EmployeeDepartment
                {
                    EmployeeId = item,
                    DepartmentId = DeptId
                };
                _employeeDepartmentRepository.AddEmployeeDepartment(employeeDepartment);
            }
            return RedirectToAction("EditEmpToDept");
        }
        //Dashboard
        public IActionResult Dashboard()
        {
            //Bar chart
            var deptNames = _departmentRepository.GetAllDepartment().Select(x => x.Name).ToList();          
            var deptIds = _departmentRepository.GetAllDepartment().Select(x => x.Id).ToList();
            List<int> count = new List<int>();
            foreach (var deptId in deptIds)
            {
                count.Add(_employeeDepartmentRepository.FindEmpsByDeptId(deptId).Count());
            }
            var countEmps = count;
            ViewBag.DeptNames = deptNames;
            ViewBag.CountEmps = countEmps;

            //Show gender percentage to pie chart
            var employees = _employeeRepository.GetAllEmployee().ToList();
            var genders = _employeeRepository.GetAllEmployee().Select(x => x.Gender).Distinct().ToList();
            List<int> countG = new List<int>();
            foreach (var gender in genders)
            {
                countG.Add(employees.Count(x => x.Gender.Equals(gender)));
            }
            var countGenders = countG;
            ViewBag.Genders = genders;
            ViewBag.CountGenders = countGenders;
            return View();
        }
    }
}
