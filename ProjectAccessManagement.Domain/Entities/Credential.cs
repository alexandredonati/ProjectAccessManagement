using ProjectAccessManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectAccessManagement.Domain.Entities
{
    public class Credential
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public App Application { get; private set; }
        public CredentialType CredentialType { get; private set; }
        public DateTime ExpiryDate { get; private set; } = DateTime.MaxValue;
        public bool AllowsMultiAccess { get; private set; }
        public ICollection<Module> Modules { get; private set; } = [];

        protected Credential() { } // Constructor for EF Core

        public Credential(string credentialName, App application, CredentialType type)
        {
            if (application == null)
            {
                throw new ArgumentNullException("Application cannot be null.");
            };
            Name = credentialName;
            Application = application;
            CredentialType = type;
        }

        public Credential(string credentialName, App application, CredentialType type, DateTime expireDate)
        {
            if (application == null)
            {
                throw new ArgumentNullException("Application cannot be null.");
            };
            Name = credentialName;
            Application = application;
            CredentialType = type;
            ExpiryDate = expireDate;
        }

        public void AddModule(Module module)
        {
            if (module.Application.Id != this.Application.Id)
            {
                throw new InvalidOperationException($"Module '{module.Id}' does not belong to the application which the credential is related to.");
            }

            if (Modules.Any(m => m.Id == module.Id))
            {
                throw new InvalidOperationException("Module already belongs to credential");
            }

            Modules.Add(module);
        }

        public void AddModule(string moduleName)
        {
            if (Modules.Any(m => m.Name == moduleName))
            {
                throw new InvalidOperationException("Module already belongs to credential");
            }

            try
            {
                Application.AddModule(moduleName);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var module = Application.Modules.First(m => m.Name == moduleName);

            Modules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            if (!Modules.Any(m => m.Id == module.Id))
            {
                throw new InvalidOperationException("Module does not belong to credential");
            }
            Modules.Remove(module);
        }

        public void RemoveModule(string moduleName)
        {
            var module = Modules.FirstOrDefault(m => m.Name == moduleName);
            if (module == null)
            {
                throw new InvalidOperationException("Module does not belong to credential");
            }

            Modules.Remove(module);
        }

        public void UpdateExpireDate(DateTime newDate)
        {
            ExpiryDate = newDate;
        }

        public void SetMultiAccess(bool allow)
        {
            AllowsMultiAccess = allow;
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }
    }
}

