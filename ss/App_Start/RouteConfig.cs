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

            //routes.MapRoute(
            //    name: "GetAllStudents",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Student", action = "GetAllStudents" }
            //);

            routes.MapRoute(
                name: "GetAllDepartments",
                url: "{controller}/{action}",
                defaults: new { controller = "Department", action = "GetAllDepartments" }
            );

            //routes.MapRoute(
            //    name: "GetAllCourses",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Course", action = "GetAllCourses" }
            //);

            // routes.MapRoute(
            //    name: "InsertStudent",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Student", action = "InsertStudent" }
            //);

            // routes.MapRoute(
            //    name: "DeleteStudent",
            //    url: "{controller}/{action}/{Id}",
            //    defaults: new { controller = "Student", action = "DeleteStudent", Id = 2 }
            //);
        }
    }
}
