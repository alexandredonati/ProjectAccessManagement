using ProjectAccessManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ApplicationType AppType { get; set; }

        public ICollection<Module> Modules { get; set; } = [];

        public Application(string name, ApplicationType appType)
        {
            Name = name;
            AppType = appType;
        }
    }
}
