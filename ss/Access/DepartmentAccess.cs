using Dapper;
using Newtonsoft.Json;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss.Access
{
    public class DepartmentAccess
    {
        string ConnectionString = @"Data Source=laptop-q6s7b3ka;Initial Catalog = StudentManagementSystem; Integrated Security = True";
        public List<Department> GetSingleDepartment(int DepartmentId)
        {
            List<Department> departmentDetails = new List<Department>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                departmentDetails = connection.Query<Department>("SELECT * FROM Department Where Id = " + DepartmentId).ToList();
            }

            return departmentDetails;
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> AllDepartmentsDetails = new List<Department>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               
                AllDepartmentsDetails = connection.Query<Department>("SELECT * FROM Department").ToList();
            }

            return AllDepartmentsDetails;
        }
        public string InsertDepartment(Department department)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var departments = connection.Execute("Insert into Department (DepartmentName) values (@DepartmentName)", new { DepartmentName = department.DepartmentName });

                var Departments = JsonConvert.SerializeObject(departments);
                return Departments;
            }
        }

        public string UpdateDepartments(int DepartmentId, Department department)
        {
            string query = "UPDATE Department set DepartmentName = '" + department.DepartmentName + "' WHERE DepartmentId = " + DepartmentId;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var departments = connection.Execute(query);

                var Departments = JsonConvert.SerializeObject(departments);
                return Departments;
            }
        }

        public string DeleteDepartment(int DepartmentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var departments = connection.Execute("Delete FROM Department Where DepartmentId = @DepartmentId", new { DepartmentId = DepartmentId });

                var Departments = JsonConvert.SerializeObject(departments);
                return Departments;
            }
        }
    }
}