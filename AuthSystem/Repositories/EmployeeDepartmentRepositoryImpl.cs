﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models.Application
{
    public class EmployeeDepartmentRepositoryImpl : IEmployeeDepartmentRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeDepartmentRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddEmpDept(List<EmployeeDepartment> empDepts)
        {
            foreach (var item in empDepts)
            {
                context.EmployeeDepartments.Add(item);
                context.SaveChanges();
            }
            return true;
        }

        public EmployeeDepartment AddEmployeeDepartment(EmployeeDepartment empDept)
        {
            throw new NotImplementedException();
        }

        public void Delete(EmployeeDepartment empDept)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeDepartment> FindEmpsByDeptId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
