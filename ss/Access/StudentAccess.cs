using Dapper;
using Newtonsoft.Json;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss.Access
{
    public class StudentAccess
    {
        // string ConnectionString = ConfigurationManager.ConnectionStrings["STMconnectionString"].ConnectionString;
        string ConnectionString = @"Data Source=laptop-q6s7b3ka;Initial Catalog = StudentManagementSystem; Integrated Security = True";
        
        //string ConnectionString = @"Data Source=LAPTOP-Q6S7B3KA;Initial Catalog=StudentManagementSystem;User ID=;Password=";
        public List<Student> GetSingleStudent(int StudentId)
        {
            List<Student> studentDetails = new List<Student>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                studentDetails = connection.Query<Student>("SELECT StudentId, StudentName, ContactNo, DOB, Gender, Address, DepartmentName, CourseName FROM Student LEFT JOIN Department ON Department.DepartmentId = Student.DepartmentId LEFT JOIN Course ON Course.CourseId = Student.CourseId Where Id = " + StudentId).ToList();
            }

            return studentDetails;
        }

        public List<Student> GetAllStudents()
        {
            string query = "SELECT s.* FROM Student s LEFT JOIN Department d ON d.DepartmentId = s.DepartmentId LEFT JOIN Course c ON c.CourseId = s.CourseId";
            List<Student> studentAllDetails = new List<Student>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                
                var result = connection.Query<Student>(query).ToList();
                studentAllDetails = result;
                
            }
            
            return studentAllDetails;
        }
        public string InsertStudent(Student student)
        {
          
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var students = connection.Execute("Insert into Student (StudentName, ContactNo, DOB, Gender, Address, DepartmentId, DepartmentName, CourseId, CourseName) values (@StudentName, @ContactNo, @DOB, @Gender, @Address, @DepartmentId, @DepartmentName, @CourseId, @CourseName)", new { StudentName = student.StudentName, ContactNo = student.ContactNo, DOB = student.DOB, Gender = student.Gender, Address = student.Address, DepartmentId = student.DepartmentId, DepartmentName = student.DepartmentName, CourseId = student.CourseId, CourseName = student.CourseName });

                var Students = JsonConvert.SerializeObject(students);
                return Students;
            }
        }

        public string UpdateStudents(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var students = connection.Execute("UPDATE Student set StudentName='" + student.StudentName + "',ContactNo='" + student.ContactNo + "', DOB='" + student.DOB + "', Gender='" + student.Gender + "', Address='" + student.Address + "', DepartmentName='" + student.DepartmentName + "', CourseName='" + student.CourseName + "' WHERE Id=" + student.StudentId);

                var Students = JsonConvert.SerializeObject(students);
                return Students;
            }
        }

        public string DeleteStudent(Student student)
        {
            //Student student = new Student();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var students = connection.Execute("Delete FROM Student Where Id = @StudentId", new { Id = student.StudentId });

                var Students = JsonConvert.SerializeObject(students);
                return Students;
            }
        }
    }
}