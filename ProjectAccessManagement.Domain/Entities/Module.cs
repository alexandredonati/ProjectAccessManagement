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
        public App Application { get; private set; }

        protected Module() { }

        public Module(string name, App application)
        {
            Name = name;
            Application = application;
        }
    }
}
