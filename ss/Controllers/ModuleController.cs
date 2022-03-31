using Newtonsoft.Json;
using ss.Manager;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ss.Controllers
{
    public class ModuleController
    {
        private readonly ModuleManager moduleManager;

        public ModuleController()
        {
            this.moduleManager = new ModuleManager();
        }

        [HttpGet]
        public List<Module> GetSingleModule(int ModuleId)
        {
            List<Module> moduleList = new List<Module>();
            moduleList = moduleManager.GetSingleModule(ModuleId);
            return moduleList;
        }

        [HttpGet]
        //[Route("get-all-modules")]
        public string GetAllModules()
        {
            //List<Module> moduleList = new List<Module>();
            var moduleList = moduleManager.GetAllModules();

            var ModuleList = JsonConvert.SerializeObject(moduleList);
            return ModuleList;

        }

        [HttpPost]
        //[Route("module")]
        public string InsertModule(Module module)
        {
            var modul = moduleManager.InsertModule(module);
            return modul;

        }

        [HttpPut]
        //[Route("{id}/update-module")]
        public string UpdateModules(int id, Module module, Course course)
        {
            var modul = moduleManager.UpdateModules(id, module, course);
            return modul;
        }

        [HttpDelete]
        //[Route("{id}/delete-module")]
        public string DeleteModule(int id)
        {
            var module = moduleManager.DeleteModule(id);
            return module;
        }
    }
}