using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class BusinessArea
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Automation> Automations { get; private set; } = [];

        public BusinessArea(string name) 
        {
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
