using ss.Access;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss.Manager
{
    public class CourseManager
    {
        private readonly CourseAccess courseAccess;

        public CourseManager()
        {
            this.courseAccess = new CourseAccess();
        }
        public List<Course> GetSingleCourse(int CourseId)
        {
            return courseAccess.GetSingleCourse(CourseId);

        }

        public List<Course> GetAllCourses()
        {
            return courseAccess.GetAllCourses();

        }
    }
}