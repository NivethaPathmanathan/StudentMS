﻿using Newtonsoft.Json;
using ss.Manager;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ss.Controllers
{
    //[RoutePrefix("api/student")]
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
            public string GetAllStudents()
            {
               //List<Student> studentList = new List<Student>();
               var studentList = studentManager.GetAllStudents();

                var StudentList = JsonConvert.SerializeObject(studentList);
                return StudentList;

            }


            [HttpPost]
            [Route("student")]
            public string InsertStudent(Student student)
            {
                var student1 = studentManager.InsertStudent(student);
                return student1;

            }

            [HttpPut]
            //[Route("{id}/update-student")]
            public string UpdateStudents(Student student)
            {
                var student1 = studentManager.UpdateStudents(student);
                return student1;
            }

            [HttpDelete]
            //[Route("{id}/delete-student")]
            public string DeleteStudent(Student student)
            {
                var student1 = studentManager.DeleteStudent(student);
                return student1;
            }
    }
}