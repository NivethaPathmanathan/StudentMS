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
        //[Route("{id}")]
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

        [HttpPost]
        //[Route("course")]
        public string InsertCourse(Course course)
        {
            var course1 = courseManager.InsertCourse(course);
            return course1;

        }

        [HttpPut]
        //[Route("{id}/update-course")]
        public string UpdateCourses(int id, Course course, Department department)
        {
            var course1 = courseManager.UpdateCourses(id, course, department);
            return course1;
        }

        [HttpDelete]
        //[Route("{id}/delete-course")]
        public string DeleteCourse(int id)
        {
            var course1 = courseManager.DeleteCourse(id);
            return course1;
        }
    }
}