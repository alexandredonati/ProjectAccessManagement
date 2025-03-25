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
        private readonly IMapper _mapper;

        public CredentialService(ICredentialRepository credentialRepository, IMapper mapper)
        {
            _credentialRepository = credentialRepository;
            _mapper = mapper;
        }

        public CredentialOutputDto CreateCredential(NewCredentialDto dto)
        {
            var existingCredential = _credentialRepository.GetAll()
                .FirstOrDefault(c => (c.Name == dto.Name && c.Application.Id == dto.ApplicationId));

            if (existingCredential == null)
            {
                throw new Exception($"Credential with name '{dto.Name} already exists for this application!");
            }

            var application = _applicationRepository.GetById(dto.ApplicationId);
            if (application == null)
            {
                throw new Exception("Application not found!");
            }

            if (Enum.TryParse<CredentialType>(dto.CredentialType, true, out var type))
            {
                throw new Exception("Invalid credential type!");
            }

            var credential = new Credential(dto.Name, application, type);

            foreach (var moduleDto in dto.Modules)
            {
                try
                {
                    if (moduleDto.Id != Guid.Empty)
                    {
                        var module = application.Modules.FirstOrDefault(m => m.Id == moduleDto.Id);
                        if (module == null)
                        {
                            throw new Exception("Module not found!");
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

        public void AdicionarModuloACredencial()
        {

        }
    }
}
