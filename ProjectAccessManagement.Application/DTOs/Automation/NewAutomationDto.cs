using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
