using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.DTOs.App
{
    public class AppSimpleDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
