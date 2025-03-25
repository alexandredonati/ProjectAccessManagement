using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectAccessManagement.Application.DTOs.Automation;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.Services
{
    public class AutomationService
    {
        private readonly IAutomationRepository _automationRepository;
        private readonly IBusinessAreaRepository _businessAreaRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly ICredentialRepository _credentialRepository;
        private readonly IMapper _mapper;

        public AutomationService(IAutomationRepository automationRepository, IBusinessAreaRepository businessAreaRepository, IModuleRepository moduleRepository, ICredentialRepository credentialRepository, IMapper mapper)
        {
            _automationRepository = automationRepository;
            _businessAreaRepository = businessAreaRepository;
            _moduleRepository = moduleRepository;
            _credentialRepository = credentialRepository;
            _mapper = mapper;
        }

        public AutomationOutputDto CreateAutomation(NewAutomationDto dto)
        {
            var businessArea = _businessAreaRepository.GetById(dto.BusinessAreaId);

            if (businessArea == null)
            {
                throw new Exception("Business area not found!");
            }

            var existingAutomation = _automationRepository.GetAll()
                .FirstOrDefault(a => a.Name == dto.Name && a.BusinessId == dto.BusinessId);

            if (existingAutomation != null)
            {
                throw new Exception("An automation with the same name and business ID already exists!");
            }

            var automation = new Automation(dto.Name, businessArea, dto.BusinessId);
            _automationRepository.Add(automation);
            return _mapper.Map<AutomationOutputDto>(automation);
        }

        public void DeleteAutomation(Guid automationId)
        {
            var automation = _automationRepository.GetById(automationId);
            if (automation == null)
            {
                throw new Exception("Automation not found!");
            }
            _automationRepository.Delete(automationId);
        }

        public AutomationOutputDto AddModulesAndCredentialsToAutomation(AutomationUpdateDto dto)
        {
            List<string> errors = new List<string>();

            var automation = _automationRepository.GetById(dto.Id);
            if (automation == null)
            {
                throw new Exception($"Automation with ID {dto.Id} not found!");
            }

            foreach (var moduleId in dto.ModulesIds)
            {
                try
                {
                    var module = _moduleRepository.GetById(moduleId);
                    if (module == null)
                    {
                        throw new Exception($"Module with ID {moduleId} not found!");
                    }
                    automation.AddModule(module);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }

            foreach (var credentialId in dto.CredentialsIds)
            {
                try
                {
                    var credential = _credentialRepository.GetById(credentialId);
                    if (credential == null)
                    {
                        throw new Exception($"Credential with ID {credentialId} not found!");
                    }
                    automation.AddCredential(credential);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }

            _automationRepository.Update(automation);
            var result = _mapper.Map<AutomationOutputDto>(automation);
            result.Errors = errors;
            return result;
        }
        public AutomationOutputDto RemoveModulesAndCredentialsFromAutomation(AutomationUpdateDto dto)
        {
            List<string> errors = new List<string>();

            var automation = _automationRepository.GetById(dto.Id);
            if (automation == null)
            {
                throw new Exception($"Automation with ID {dto.Id} not found!");
            }

            foreach (var moduleId in dto.ModulesIds)
            {
                try
                {
                    var module = _moduleRepository.GetById(moduleId);
                    if (module == null)
                    {
                        throw new Exception($"Module with ID {moduleId} not found!");
                    }
                    automation.RemoveModule(module);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }

            foreach (var credentialId in dto.CredentialsIds)
            {
                try
                {
                    var credential = _credentialRepository.GetById(credentialId);
                    if (credential == null)
                    {
                        throw new Exception($"Credential with ID {credentialId} not found!");
                    }
                    automation.RemoveCredential(credential);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }

            _automationRepository.Update(automation);
            var result = _mapper.Map<AutomationOutputDto>(automation);
            result.Errors = errors;
            return result;
        }

        public IEnumerable<AutomationOutputDto> GetAllAutomations()
        {
            var automations = _automationRepository.GetAll();
            return _mapper.Map<IEnumerable<AutomationOutputDto>>(automations);
        }
    }
}
