using Microsoft.AspNetCore.Mvc;
using ProjectAccessManagement.Application.DTOs.Automation;
using ProjectAccessManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAccessManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomationsController : ControllerBase
    {
        private readonly AutomationService _automationService;

        public AutomationsController(AutomationService automationService)
        {
            _automationService = automationService;
        }

        [HttpPost]
        public async Task<ActionResult<AutomationOutputDto>> CreateAutomation([FromBody] NewAutomationDto dto)
        {
            try
            {
                var result = _automationService.CreateAutomation(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutomationOutputDto>>> GetAllAutomations()
        {
            try
            {
                var result = _automationService.GetAllAutomations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("{id}/modules-and-credentials")]
        public async Task<ActionResult<AutomationOutputDto>> AddModulesAndCredentials(
            Guid id,
            [FromBody] AutomationUpdateDto dto)
        {
            try
            {
                dto.Id = id;
                var result = _automationService.AddModulesAndCredentialsToAutomation(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}/modules-and-credentials")]
        public async Task<ActionResult<AutomationOutputDto>> RemoveModulesAndCredentials(
            Guid id,
            [FromBody] AutomationUpdateDto dto)
        {
            try
            {
                dto.Id = id;
                var result = _automationService.RemoveModulesAndCredentialsFromAutomation(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAutomation(Guid id)
        {
            try
            {
                _automationService.DeleteAutomation(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
} 