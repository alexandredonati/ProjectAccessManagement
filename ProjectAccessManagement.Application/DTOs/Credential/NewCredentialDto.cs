using ProjectAccessManagement.Application.DTOs.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.Credential
{
    public class NewCredentialDto
    {
        public string Name { get; set; }
        public string CredentialType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool AllowsMultiAccess { get; set; }
        public Guid ApplicationId { get; set; }
        public IEnumerable<ModuleSimpleDto> Modules { get; set; }
    }
}
