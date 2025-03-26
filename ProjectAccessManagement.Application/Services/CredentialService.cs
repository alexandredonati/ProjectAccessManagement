using AutoMapper;
using ProjectAccessManagement.Application.DTOs.Credential;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;
using ProjectAccessManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.Services
{
    public class CredentialService
    {
        private readonly ICredentialRepository _credentialRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public CredentialService(
            ICredentialRepository credentialRepository,
            IApplicationRepository applicationRepository,
            IModuleRepository moduleRepository,
            IMapper mapper)
        {
            _credentialRepository = credentialRepository;
            _applicationRepository = applicationRepository;
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public CredentialOutputDto CreateCredential(NewCredentialDto dto)
        {
            var existingCredential = _credentialRepository.GetAll()
                .FirstOrDefault(c => (c.Name == dto.Name && c.Application.Id == dto.ApplicationId));

            if (existingCredential != null)
            {
                throw new Exception($"Credential with name '{dto.Name}' already exists for this application!");
            }

            var application = _applicationRepository.GetById(dto.ApplicationId);
            if (application == null)
            {
                throw new Exception("Application not found!");
            }

            if (!Enum.TryParse<CredentialType>(dto.CredentialType, true, out var type))
            {
                throw new Exception("Invalid credential type!");
            }

            var errors = new List<string>();

            var credential = new Credential(dto.Name, application, type);

            foreach (var moduleDto in dto.Modules)
            {
                try
                {
                    if (moduleDto.Id != Guid.Empty)
                    {
                        var module = _moduleRepository.GetById(moduleDto.Id);
                        if (module == null)
                        {
                            errors.Add($"Module with ID {moduleDto.Id} not found!");
                        }
                        credential.AddModule(module);
                    }
                    else if (!String.IsNullOrEmpty(moduleDto.Name))
                    {
                        credential.AddModule(moduleDto.Name);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding module: {ex.Message}");
                }
            }

            _credentialRepository.Add(credential);
            return _mapper.Map<CredentialOutputDto>(credential);
        }

        public CredentialOutputDto AddModulesToCredential(UpdateModulesInCredentialDto dto)
        {
            var credential = _credentialRepository.GetById(dto.CredentialId);
            if (credential == null)
            {
                throw new Exception($"Credential with ID {dto.CredentialId} not found!");
            }

            var errors = new List<string>();

            foreach (var moduleDto in dto.Modules)
            {
                try
                {
                    if (moduleDto.Id != Guid.Empty)
                    {
                        var module = _moduleRepository.GetById(moduleDto.Id);
                        if (module == null)
                        {
                            errors.Add($"Module with ID {moduleDto.Id} not found!");
                            continue;
                        }
                        credential.AddModule(module);
                    }
                    else if (!String.IsNullOrEmpty(moduleDto.Name))
                    {
                        credential.AddModule(moduleDto.Name);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"Error adding module: {ex.Message}");
                }
            }

            _credentialRepository.Update(credential);
            var result = _mapper.Map<CredentialOutputDto>(credential);
            result.Errors = errors;
            return result;
        }

        public CredentialOutputDto RemoveModulesFromCredential(UpdateModulesInCredentialDto dto)
        {
            var credential = _credentialRepository.GetById(dto.CredentialId);
            if (credential == null)
            {
                throw new Exception($"Credential with ID {dto.CredentialId} not found!");
            }

            var errors = new List<string>();

            foreach (var moduleDto in dto.Modules)
            {
                try
                {
                    if (moduleDto.Id != Guid.Empty)
                    {
                        var module = _moduleRepository.GetById(moduleDto.Id);
                        if (module == null)
                        {
                            errors.Add($"Module with ID {moduleDto.Id} not found!");
                            continue;
                        }
                        credential.RemoveModule(module);
                    }
                    else if (!String.IsNullOrEmpty(moduleDto.Name))
                    {
                        credential.RemoveModule(moduleDto.Name);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"Error removing module: {ex.Message}");
                }
            }

            _credentialRepository.Update(credential);
            var result = _mapper.Map<CredentialOutputDto>(credential);
            result.Errors = errors;
            return result;
        }

        public CredentialOutputDto UpdateCredential(UpdateCredentialDto dto)
        {
            var credential = _credentialRepository.GetById(dto.CredentialId);
            if (credential == null)
            {
                throw new Exception($"Credential with ID {dto.CredentialId} not found!");
            }

            if (dto.NewExpiryDate.HasValue)
            {
                credential.UpdateExpireDate(dto.NewExpiryDate.Value);
            }

            if (dto.AllowMultiAccess.HasValue)
            {
                credential.SetMultiAccess(dto.AllowMultiAccess.Value);
            }

            _credentialRepository.Update(credential);
            return _mapper.Map<CredentialOutputDto>(credential);
        }

        public IEnumerable<CredentialOutputDto> GetAllCredentials()
        {
            var credentials = _credentialRepository.GetAll();
            return _mapper.Map<IEnumerable<CredentialOutputDto>>(credentials);
        }

        public CredentialOutputDto GetCredentialById(Guid credentialId)
        {
            var credential = _credentialRepository.GetById(credentialId);
            if (credential == null)
            {
                throw new Exception($"Credential with ID {credentialId} not found!");
            }

            return _mapper.Map<CredentialOutputDto>(credential);
        }

        public void DeleteCredential(Guid credentialId)
        {
            var credential = _credentialRepository.GetById(credentialId);
            if (credential == null)
            {
                throw new Exception($"Credential with ID {credentialId} not found!");
            }

            _credentialRepository.Delete(credentialId);
        }
    }
}
