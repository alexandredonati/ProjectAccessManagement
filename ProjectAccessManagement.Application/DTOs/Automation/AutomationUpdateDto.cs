using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.Automation
{
    public class AutomationUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public IEnumerable<Guid> ModulesIds { get; set; }
        public IEnumerable<Guid> CredentialsIds { get; set; }
    }
}
