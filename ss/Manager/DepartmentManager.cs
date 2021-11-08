using ss.Access;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss.Manager
{
    public class DepartmentManager
    {
        private readonly DepartmentAccess departmentAccess;

        public DepartmentManager()
        {
            this.departmentAccess = new DepartmentAccess();
        }
        public List<Department> GetSingleDepartment(int DepartmentId)
        {
            return departmentAccess.GetSingleDepartment(DepartmentId);

        }

        public List<Department> GetAllDepartments()
        {
            return departmentAccess.GetAllDepartments();

        }

        public string InsertDepartment(Department department)
        {
            return departmentAccess.InsertDepartment(department);

        }
        public string UpdateDepartments(int DepartmentId, Department department)
        {
            return departmentAccess.UpdateDepartments(DepartmentId, department);
        }

        public string DeleteDepartment(int DepartmentId)
        {
            return departmentAccess.DeleteDepartment(DepartmentId);
        }
    }
}