using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.App
{
    public class NewAppDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public List<string> ModulesNames { get; set; }
    }
}
