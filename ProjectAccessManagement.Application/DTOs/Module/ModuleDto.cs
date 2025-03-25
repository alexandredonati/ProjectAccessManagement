using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.Module
{
    public class ModuleDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string ApplicationName { get; private set; }
        public string ApplicationType { get; private set; }
    }
}
