using ProjectAccessManagement.Application.DTOs.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.BusinessArea
{
    public class BusinessAreaOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AutomationSimpleOutputDto> Automations { get; set; }
    }
}
