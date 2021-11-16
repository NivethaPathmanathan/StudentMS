using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ss.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }
       
        //[Column("DepartmentId")]
        //public Department Department { get; set; }

        [IgnoreInsert]
        [Dapper.Column("DepartmentId")]
        public Department Department { get; set; }

        [IgnoreSelect]
        [IgnoreDataMember]
        public int DepartmentId { get; set; }

    }
}