using Dapper;
using Newtonsoft.Json;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ss.Access
{
    public class ModuleAccess
    {
        string ConnectionString = @"Data Source=laptop-q6s7b3ka;Initial Catalog = StudentManagementSystem; Integrated Security = True";
        public List<Module> GetSingleModule(int ModuleId)
        {
            string query = "SELECT * FROM Module m LEFT JOIN Course c ON c.CourseId = m.CourseId Where Id = " + ModuleId;
            List<Module> moduleDetails = new List<Module>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                moduleDetails = connection.Query<Module>(query).ToList();
            }

            return moduleDetails;
        }

        public List<Module> GetAllModules()
        {
            string query = "Select * FROM Module INNER JOIN Course ON Module.CourseId = Course.CourseId";
            List<Module> AllModulesDetails = new List<Module>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                var result = connection.Query<Module, Course, Module>(query, (module, course) =>
                {
                    module.Course = course;
                    return module;
                },
                splitOn: "CourseId")
                    .Distinct()
                .ToList();
                AllModulesDetails = result;

            }

            return AllModulesDetails;
        }

        public string InsertModule(Module module)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var modules = connection.Execute("Insert into Module (ModuleName, Credits, CourseId, CourseName) values (@ModuleName, @Credits, @CourseId, @CourseName)", new { ModuleName = module.ModuleName, Credits = module.Credits, CourseId = module.Course });

                var Modules = JsonConvert.SerializeObject(modules);
                return Modules;
            }
        }

        public string UpdateModules(int ModuleId, Module module, Course course)
        {
            string query = "UPDATE Module set ModuleName = '" + module.ModuleName + "', Credits = '" + module.Credits + "' WHERE ModuleId = " + ModuleId;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var modules = connection.Execute(query);

                var Modules = JsonConvert.SerializeObject(modules);
                return Modules;
            }
        }

        public string DeleteModule(int ModuleId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var modules = connection.Execute("Delete FROM Module Where ModuleId = @ModuleId", new { ModuleId = ModuleId });

                var Modules = JsonConvert.SerializeObject(modules);
                return Modules;
            }
        }
    }
}