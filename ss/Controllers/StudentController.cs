using Newtonsoft.Json;
using ss.Manager;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace ss.Controllers
{
    //[RoutePrefix("api/student")]
    //[Route("/api/student")]
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : Controller
    {
            private readonly StudentManager studentManager;

            public StudentController()
            {
                this.studentManager = new StudentManager();
            }
            [HttpGet]
            //[Route("{id}")]
            public List<Student> GetSingleStudent(int StudentId)
            {
                List<Student> studentList = new List<Student>();
                studentList = studentManager.GetSingleStudent(StudentId);
                return studentList;

            }

            [HttpGet]
            //[Route("get-all-students")]
            //[Route("/get-all-students")]
            public string GetAllStudents()
            {
               //List<Student> studentList = new List<Student>();
               var studentList = studentManager.GetAllStudents();

                var StudentList = JsonConvert.SerializeObject(studentList);
                return StudentList;

            }

           // [DisableCors()]
            [HttpPost]
            // [Route("student")]
            public string InsertStudent(Student student)
            {
                var student1 = studentManager.InsertStudent(student);
                return student1;

            }

            [HttpPut]
            //[Route("{id}/update-student")]
            public string UpdateStudents(int id, Student student, Department department, Course course)
            {
                var student1 = studentManager.UpdateStudents(id, student, department, course);
                return student1;
            }

            [HttpDelete]
            //[Route("{id}/delete-student")]
            public string DeleteStudent(int id)
            {
                var student1 = studentManager.DeleteStudent(id);
                return student1;
            }
    }
}