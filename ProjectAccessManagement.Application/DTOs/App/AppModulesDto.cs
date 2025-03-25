using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.App
{
    public class AppModulesDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public List<string> ModulesNames { get; set; }
    }
}
