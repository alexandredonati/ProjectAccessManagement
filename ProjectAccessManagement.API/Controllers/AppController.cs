using Microsoft.AspNetCore.Mvc;
using ProjectAccessManagement.Application.DTOs.App;
using ProjectAccessManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAccessManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private readonly AppService _applicationService;

        public AppController(AppService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<ActionResult<AppOutputDto>> CreateApp([FromBody] NewAppDto dto)
        {
            try
            {
                var result = _applicationService.CreateApp(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppOutputDto>>> GetAllApps()
        {
            try
            {
                var result = _applicationService.GetAllApps();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppOutputDto>> GetAppById(Guid id)
        {
            try
            {
                var result = _applicationService.GetAppById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplication(Guid id)
        {
            try
            {
                _applicationService.DeleteApp(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
} 