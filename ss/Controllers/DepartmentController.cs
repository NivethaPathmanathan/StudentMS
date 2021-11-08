using Newtonsoft.Json;
using ss.Manager;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ss.Controllers
{
    //  [RoutePrefix("api/department/")]
    public class DepartmentController : Controller
    {
        private readonly DepartmentManager departmentManager;

        public DepartmentController()
        {
            this.departmentManager = new DepartmentManager();
        }
        [HttpGet]
        //[Route("{id}")]
        public List<Department> GetSingleDepartment(int DepartmentId)
        {
            List<Department> departmentList = new List<Department>();
            departmentList = departmentManager.GetSingleDepartment(DepartmentId);
            return departmentList;

        }

        [HttpGet]
        //[Route("get-all-departments")]
        public string GetAllDepartments()
        {
            //List<Department> departmentList = new List<Department>();
            var departmentList = departmentManager.GetAllDepartments();

            var DepartmentList = JsonConvert.SerializeObject(departmentList);
            return DepartmentList;

        }

        [HttpPost]
        //[Route("department")]
        public string InsertDepartment(Department department)
        {
            var department1 = departmentManager.InsertDepartment(department);
            return department1;

        }

        [HttpPut]
        //[Route("{id}/update-department")]
        public string UpdateDepartments(int id, Department department)
        {
            var department1 = departmentManager.UpdateDepartments(id, department);
            return department1;
        }

        [HttpDelete]
        //[Route("{id}/delete-department")]
        public string DeleteDepartment(int id)
        {
            var department1 = departmentManager.DeleteDepartment(id);
            return department1;
        }

    }
}