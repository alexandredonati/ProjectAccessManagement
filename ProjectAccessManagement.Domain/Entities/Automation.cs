using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Entities
{
    public class Automation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
        public BusinessArea BusinessArea { get; set; }

        public Automation(string name, BusinessArea businessArea, int businessId) 
        {
            Name = name;
            BusinessArea = businessArea;
            BusinessId = businessId;
        }
    }
}
