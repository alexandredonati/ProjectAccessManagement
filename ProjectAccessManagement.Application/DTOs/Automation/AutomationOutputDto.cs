using ProjectAccessManagement.Application.DTOs.Credential;
using ProjectAccessManagement.Application.DTOs.Module;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAccessManagement.Application.DTOs.Automation
{
    public class AutomationOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
        public Guid BusinessAreaId { get; set; }
        public string BusinessAreaName { get; set; }
        public IEnumerable<ModuleDto> Modules { get; set; }
        public IEnumerable<CredentialOutputDto> Credentials { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}