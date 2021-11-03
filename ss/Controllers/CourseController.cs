using Newtonsoft.Json;
using ss.Manager;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ss.Controllers
{//  [RoutePrefix("api/course/")]
    public class CourseController : Controller
    {
        private readonly CourseManager courseManager;

        public CourseController()
        {
            this.courseManager = new CourseManager();
        }
        [HttpGet]
        [Route("{id}")]
        public List<Course> GetSingleCourse(int CourseId)
        {
            List<Course> courseList = new List<Course>();
            courseList = courseManager.GetSingleCourse(CourseId);
            return courseList;

        }

        [HttpGet]
        //[Route("get-all-courses")]
        public string GetAllCourses()
        {
            //List<Course> courseList = new List<Course>();
            var courseList = courseManager.GetAllCourses();

            var CourseList = JsonConvert.SerializeObject(courseList);
            return CourseList;

        }

    }
}