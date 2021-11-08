using ss.Access;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss.Manager
{
    public class StudentManager
    {
        private readonly StudentAccess studentAccess;

        public StudentManager()
        {
            this.studentAccess = new StudentAccess();
        }
        public List<Student> GetSingleStudent(int StudentId)
        {
            return studentAccess.GetSingleStudent(StudentId);

        }

        public List<Student> GetAllStudents()
        {
            return studentAccess.GetAllStudents();

        }


        public string InsertStudent(Student student)
        {
            return studentAccess.InsertStudent(student);

        }
        public string UpdateStudents(int StudentId, Student student, Department department, Course course)
        {
            return studentAccess.UpdateStudents(StudentId, student, department, course);
        }

        public string DeleteStudent(int StudentId)
        {
            return studentAccess.DeleteStudent(StudentId);
        }
    }
}