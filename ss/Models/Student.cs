using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss.Models
{
    public class Student
    {
        //public Student()
        //{
        //    this.Department = new Department();
        //}
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int ContactNo { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public Department DepartmentId { get; set; }

        public Course CourseId { get; set; }

    }
}