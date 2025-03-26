using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class Automation
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public int BusinessId { get; private set; }
        public BusinessArea BusinessArea { get; private set; }
        public ICollection<Module> Modules { get; private set; } = [];
        public ICollection<Credential> Credentials { get; private set; } = [];


        public Automation(string name, BusinessArea businessArea, int businessId)
        {
            Name = name;
            BusinessArea = businessArea;
            BusinessId = businessId;
        }

        public void AddModule(Module module)
        {
            if (Modules.Any(m => m.Id == module.Id))
            {
                throw new InvalidOperationException($"Module '{module.Name}' already belongs to automation '{Name}'");
            }
            Modules.Add(module);
        }

        public void AddCredential(Credential credential)
        {
            if (Credentials.Any(c => c.Id == credential.Id))
            {
                throw new InvalidOperationException($"Credential '{credential.Name}' already belongs to automation '{Name}'");
            }
            Credentials.Add(credential);
        }

        public void RemoveModule(Module module)
        {
            if (!Modules.Any(m => m.Id == module.Id))
            {
                throw new InvalidOperationException($"Module '{module.Name}' does not belong to automation '{Name}'");
            }
            Modules.Remove(module);
        }

        public void RemoveCredential(Credential credential)
        {
            if (!Credentials.Any(c => c.Id == credential.Id))
            {
                throw new InvalidOperationException($"Credential '{credential.Name}' does not belong to automation '{Name}'");
            }
            Credentials.Remove(credential);
        }

        public IEnumerable<App> GetApplications()
        {
            var applications = Modules.Select(m => m.Application).Distinct();
            return applications;
        }
    }
}
