using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class BusinessArea
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Automation> Automations { get; set; }

        public BusinessArea(string name) 
        {
            Name = name;
        }
    }
}
