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
    }
}