using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Dapper;

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

        [IgnoreInsert]
        [Column("DepartmentId")]
        public Department Department { get; set; }

        [IgnoreSelect]
        [IgnoreDataMember]
        public int DepartmentId { get; set; }

        [IgnoreInsert]
        [Column("CourseId")]
        public Course Course { get; set; }

        [IgnoreSelect]
        [IgnoreDataMember]
        public int CourseId { get; set; }

    }
}