using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ss
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //GetAllCourses
        //GetAllStudents
        //GetAllDepartments
            routes.MapRoute(
                name: "GetAllStudents",
                url: "{controller}/{action}",
                defaults: new { controller = "Student", action = "GetAllStudents" }
                );

            routes.MapRoute(
                name: "GetAllDepartments",
                url: "{controller}/{action}",
                defaults: new { controller = "Department", action = "GetAllDepartments" }
                );

            routes.MapRoute(
                name: "GetAllCourses",
                url: "{controller}/{action}",
                defaults: new { controller = "Course", action = "GetAllCourses" }
                );

            routes.MapRoute(
                name: "GetAllModules",
                url: "{controller}/{action}",
                defaults: new { controller = "Module", action = "GetAllModules" }
                );

            //InsertDepartment
            //InsertCourse
            //InsertStudent
            routes.MapRoute(
                name: "InsertStudent",
                url: "{controller}/{action}",
                defaults: new { controller = "Student", action = "InsertStudent" }
            );

            routes.MapRoute(
                name: "InsertDepartment",
                url: "{controller}/{action}",
                defaults: new { controller = "Department", action = "InsertDepartment" }
            );

            routes.MapRoute(
                name: "InsertCourse",
                url: "{controller}/{action}",
                defaults: new { controller = "Course", action = "InsertCourse" }
            );

            routes.MapRoute(
              name: "InsertModule",
              url: "{controller}/{action}",
              defaults: new { controller = "Module", action = "InsertModule" }
          );


            //DeleteStudent
            //DeleteCourse
            //DeleteDepartment
            routes.MapRoute(
               name: "DeleteStudent",
               url: "{controller}/{action}/{Id}",
               defaults: new { controller = "Student", action = "DeleteStudent", Id = "" }
           );

            routes.MapRoute(
              name: "DeleteCourse",
              url: "{controller}/{action}/{Id}",
              defaults: new { controller = "Course", action = "DeleteCourse", Id = "" }
          );

            routes.MapRoute(
              name: "DeleteDepartment",
              url: "{controller}/{action}/{Id}",
              defaults: new { controller = "Department", action = "DeleteDepartment", Id = "" }
          );

              routes.MapRoute(
              name: "DeleteModule",
              url: "{controller}/{action}/{Id}",
              defaults: new { controller = "Module", action = "DeleteModule", Id = "" }
          );

            //UpdateCourses
            //UpdateStudents
            //UpdateDepartments
            routes.MapRoute(
               name: "UpdateCourses",
               url: "{controller}/{action}/{Id}",
               defaults: new { controller = "Course", action = "UpdateCourses", Id = "" }
           );

            routes.MapRoute(
               name: "UpdateStudents",
               url: "{controller}/{action}/{Id}",
               defaults: new { controller = "Student", action = "UpdateStudents", Id = "" }
           );

            routes.MapRoute(
               name: "UpdateDepartments",
               url: "{controller}/{action}/{Id}",
               defaults: new { controller = "Department", action = "UpdateDepartments", Id = "" }
           );

            routes.MapRoute(
              name: "UpdateModules",
              url: "{controller}/{action}/{Id}",
              defaults: new { controller = "Module", action = "UpdateModules", Id = "" }
          );
        }
    }
}
