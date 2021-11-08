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
        string ConnectionString = @"Data Source=laptop-q6s7b3ka;Initial Catalog = StudentManagementSystem; Integrated Security = True";
        
        public List<Student> GetSingleStudent(int StudentId)
        {
            string query = "SELECT StudentId, StudentName, ContactNo, DOB, Gender, Address, d.DepartmentName, c.CourseName " +
                "FROM Student s LEFT JOIN Department d ON d.DepartmentId = s.DepartmentId " +
                "LEFT JOIN Course c ON c.CourseId = s.CourseId Where Id = " + StudentId;

            List<Student> studentDetails = new List<Student>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                studentDetails = connection.Query<Student>(query).ToList();
            }

            return studentDetails;
        }

        public List<Student> GetAllStudents()
        {
            string query = "Select * FROM Student";
            List<Student> studentAllDetails = new List<Student>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                var result = connection.Query<Student, Department>(query, (student, department)=>
                {
                    student.Department = department;
                    return student;
                },
                splitOn: "StudentId")
                    .Distinct()
                .ToList();
                studentAllDetails = result;

            }
            return studentAllDetails;
        }
        public string InsertStudent(Student student)
        {
          
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var students = connection.Execute("Insert into Student (StudentName, ContactNo, DOB, Gender, Address, DepartmentId, DepartmentName, CourseId, CourseName) values (@StudentName, @ContactNo, @DOB, @Gender, @Address, @DepartmentId, @DepartmentName, @CourseId, @CourseName)", new { StudentName = student.StudentName, ContactNo = student.ContactNo, DOB = student.DOB, Gender = student.Gender, Address = student.Address, DepartmentId = student.DepartmentId, CourseId = student.CourseId });

                var Students = JsonConvert.SerializeObject(students);
                return Students;
            }
        }

        public string UpdateStudents(int StudentId, Student student, Department department, Course course)
        {
            string query = "UPDATE Student" +
                " set StudentName = '" + student.StudentName + "',ContactNo = '" + student.ContactNo + "'," +
                " DOB = '" + student.DOB + "', Gender = '" + student.Gender + "', " +
                "Address = '" + student.Address + "', DepartmentName = '" + department.DepartmentName + "'," +
                " CourseName = '" + course.CourseName + "' " +
                "WHERE StudentId = " + StudentId;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var students = connection.Execute(query);

                var Students = JsonConvert.SerializeObject(students);
                return Students;
            }
        }

        public string DeleteStudent(int StudentId)
        {
            //Student student = new Student();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var students = connection.Execute("Delete FROM Student Where StudentId = @StudentId", new { StudentId = StudentId });

                var Students = JsonConvert.SerializeObject(students);
                return Students;
            }
        }
    }
}