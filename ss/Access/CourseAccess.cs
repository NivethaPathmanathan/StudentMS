using Dapper;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss.Access
{
    public class CourseAccess
    {
        string ConnectionString = @"Data Source=laptop-q6s7b3ka;Initial Catalog = StudentManagementSystem; Integrated Security = True";
        public List<Course> GetSingleCourse(int CourseId)
        {
            List<Course> courseDetails = new List<Course>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                courseDetails = connection.Query<Course>("SELECT * FROM Course LEFT JOIN Department ON Department.DepartmentId = Course.DepartmentId Where Id = " + CourseId).ToList();
            }

            return courseDetails;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> AllCoursesDetails = new List<Course>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                AllCoursesDetails = connection.Query<Course>("SELECT * FROM Course LEFT JOIN Department ON Department.DepartmentId = Course.DepartmentId INNER JOIN Student ON Student.CourseId = Course.CourseId").ToList();
                connection.Close();
            }

            return AllCoursesDetails;
        }
    }
}