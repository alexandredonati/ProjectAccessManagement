using Microsoft.AspNetCore.Mvc;
using ProjectAccessManagement.Application.DTOs.Credential;
using ProjectAccessManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAccessManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialsController : ControllerBase
    {
        private readonly CredentialService _credentialService;

        public CredentialsController(CredentialService credentialService)
        {
            _credentialService = credentialService;
        }

        [HttpPost]
        public async Task<ActionResult<CredentialOutputDto>> CreateCredential([FromBody] NewCredentialDto dto)
        {
            try
            {
                var result = _credentialService.CreateCredential(dto);
                return CreatedAtAction(nameof(GetCredentialById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("{credentialId}/modules")]
        public async Task<ActionResult<CredentialOutputDto>> AddModulesToCredential(
            Guid credentialId,
            [FromBody] UpdateModulesInCredentialDto dto)
        {
            try
            {
                dto.CredentialId = credentialId;
                var result = _credentialService.AddModulesToCredential(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{credentialId}/modules")]
        public async Task<ActionResult<CredentialOutputDto>> RemoveModulesFromCredential(
            Guid credentialId,
            [FromBody] UpdateModulesInCredentialDto dto)
        {
            try
            {
                dto.CredentialId = credentialId;
                var result = _credentialService.RemoveModulesFromCredential(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{credentialId}")]
        public async Task<ActionResult<CredentialOutputDto>> UpdateCredential(
            Guid credentialId,
            [FromBody] UpdateCredentialDto dto)
        {
            try
            {
                dto.CredentialId = credentialId;
                var result = _credentialService.UpdateCredential(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CredentialOutputDto>>> GetAllCredentials()
        {
            try
            {
                var result = _credentialService.GetAllCredentials();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CredentialOutputDto>> GetCredentialById(Guid id)
        {
            try
            {
                var result = _credentialService.GetCredentialById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCredential(Guid id)
        {
            try
            {
                _credentialService.DeleteCredential(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
} 