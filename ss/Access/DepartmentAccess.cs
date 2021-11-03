using Dapper;
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
                connection.Open();
                AllDepartmentsDetails = connection.Query<Department>("SELECT * FROM Department INNER JOIN Student ON Student.DepartmentId = Department.DepartmentID").ToList();
                connection.Close();
            }

            return AllDepartmentsDetails;
        }
    }
}