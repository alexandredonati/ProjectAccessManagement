using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAccessManagement.Application.DTOs.Automation
{
    public class NewAutomationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int BusinessId { get; set; }
        [Required]
        public Guid BusinessAreaId { get; set; }
    }
}
