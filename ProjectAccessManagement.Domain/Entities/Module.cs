using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class Module
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public Application Application { get; private set; }

        public Module(string name, Application application)
        {
            Name = name;
            Application = application;
        }
    }
}
