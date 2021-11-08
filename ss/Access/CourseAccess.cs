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
    public class CourseAccess
    {
        string ConnectionString = @"Data Source=laptop-q6s7b3ka;Initial Catalog = StudentManagementSystem; Integrated Security = True";
        public List<Course> GetSingleCourse(int CourseId)
        {
            string query = "SELECT * FROM Course c LEFT JOIN Department d ON d.DepartmentId = c.DepartmentId Where Id = " + CourseId;
            List<Course> courseDetails = new List<Course>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                courseDetails = connection.Query<Course>(query).ToList();
            }

            return courseDetails;
        }

        public List<Course> GetAllCourses()
        {
            string query = "SELECT * FROM Course";
            List<Course> AllCoursesDetails = new List<Course>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                AllCoursesDetails = connection.Query<Course>(query).ToList();
            }

            return AllCoursesDetails;
        }

        public string InsertCourse(Course course)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var courses = connection.Execute("Insert into Course (CourseName, Duration, DepartmentId, DepartmentName) values (@CourseName, @Duration, @DepartmentId, @DepartmentName)", new { CourseName = course.CourseName, Duration = course.Duration, DepartmentId = course.DepartmentId });

                var Courses = JsonConvert.SerializeObject(courses);
                return Courses;
            }
        }

        public string UpdateCourses(int CourseId, Course course, Department department)
        {
            string query = "UPDATE Course set CourseName = '" + course.CourseName + "', Duration = '" + course.Duration + "', DepartmentName = '" + department.DepartmentName + "' WHERE CourseId = " + CourseId;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var courses = connection.Execute(query);

                var Courses = JsonConvert.SerializeObject(courses);
                return Courses;
            }
        }

        public string DeleteCourse(int CourseId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var courses = connection.Execute("Delete FROM Course Where CourseId = @CourseId", new { CourseId = CourseId });

                var Courses = JsonConvert.SerializeObject(courses);
                return Courses;
            }
        }
    }
}