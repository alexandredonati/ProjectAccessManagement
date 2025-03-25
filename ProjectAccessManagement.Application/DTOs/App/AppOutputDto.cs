using ProjectAccessManagement.Application.DTOs.Module;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAccessManagement.Application.DTOs.App
{
    public class AppOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<ModuleSimpleDto> AppModules { get; set; }
        public List<string> Errors { get; set; }
    }
}