using ss.Access;
using ss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ss.Manager
{
    public class ModuleManager
    {
        private readonly ModuleAccess moduleAccess;

        public ModuleManager()
        {
            this.moduleAccess = new ModuleAccess();
        }

        public List<Module> GetSingleModule(int ModuleId)
        {
            return moduleAccess.GetSingleModule(ModuleId);
        }

        public List<Module> GetAllModules()
        {
            return moduleAccess.GetAllModules();
        }

        public string InsertModule(Module module)
        {
            return moduleAccess.InsertModule(module);

        }
        public string UpdateModules(int ModuleId, Module module, Course course)
        {
            return moduleAccess.UpdateModules(ModuleId, module, course);
        }

        public string DeleteModule(int ModuleId)
        {
            return moduleAccess.DeleteModule(ModuleId);
        }
    }
}