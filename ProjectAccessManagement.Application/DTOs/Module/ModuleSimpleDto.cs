using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.Module
{
    public class ModuleSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
    }
}
