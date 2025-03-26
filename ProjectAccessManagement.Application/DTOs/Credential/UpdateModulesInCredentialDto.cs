using ProjectAccessManagement.Application.DTOs.Module;
using System;
using System.Collections.Generic;

namespace ProjectAccessManagement.Application.DTOs.Credential
{
    public class UpdateModulesInCredentialDto
    {
        public Guid CredentialId { get; set; }
        public List<ModuleDto> Modules { get; set; } = new List<ModuleDto>();
    }
} 