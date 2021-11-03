using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }
        public int DepatmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}