using ProjectAccessManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class App
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public AppType AppType { get; private set; }

        public ICollection<Module> Modules { get; private set; } = [];

        public App(string name, AppType appType)
        {
            Name = name;
            AppType = appType;
        }

        public void AddModule(string moduleName)
        {
            if (Modules.Any(m => m.Name == moduleName))
            {
                throw new InvalidOperationException($"Module named '{moduleName}' already exists in application '{Name}'.");
            }
            var newModule = new Module(moduleName, this);
            Modules.Add(newModule);
        }

        public void RemoveModule(string moduleName)
        {
            var module = Modules.FirstOrDefault(m => m.Name == moduleName);
            if (module == null)
            {
                throw new InvalidOperationException($"Module named '{moduleName}' does not exist in application '{Name}'.");
            }
            Modules.Remove(module);
        }
    }
}
