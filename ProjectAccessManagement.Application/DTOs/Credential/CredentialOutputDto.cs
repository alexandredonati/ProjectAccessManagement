using ProjectAccessManagement.Application.DTOs.Module;
using ProjectAccessManagement.Application.Services;
using System;

namespace ProjectAccessManagement.Application.DTOs.Credential
{
    public class CredentialOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CredentialType { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool AllowsMultiAccess { get; set; }
        public AppService Application { get; set; }
        public IEnumerable<ModuleDto> Modules { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}