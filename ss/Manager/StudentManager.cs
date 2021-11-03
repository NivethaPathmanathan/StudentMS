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
        public string UpdateStudents(Student student)
        {
            return studentAccess.UpdateStudents(student);
        }

        public string DeleteStudent(Student student)
        {
            return studentAccess.DeleteStudent(student);
        }
    }
}