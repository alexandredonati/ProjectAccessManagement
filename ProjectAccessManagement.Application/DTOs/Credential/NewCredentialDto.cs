using ProjectAccessManagement.Application.DTOs.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAccessManagement.Application.DTOs.Credential
{
    public class NewCredentialDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CredentialType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool AllowsMultiAccess { get; set; }
        [Required]
        public Guid ApplicationId { get; set; }
        public IEnumerable<ModuleSimpleDto> Modules { get; set; }
    }
}
