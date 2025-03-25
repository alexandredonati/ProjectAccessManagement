using AutoMapper;
using Microsoft.Identity.Client;
using ProjectAccessManagement.Application.DTOs.BusinessArea;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Application.Services
{
    public class BusinessAreaService
    {
        private readonly IAutomationRepository _automationRepository;
        private readonly IBusinessAreaRepository _businessAreaRepository;
        private readonly IMapper _mapper;

        public BusinessAreaService(IAutomationRepository automationRepository, IBusinessAreaRepository businessAreaRepository, IModuleRepository moduleRepository, ICredentialRepository credentialRepository, IMapper mapper)
        {
            _automationRepository = automationRepository;
            _businessAreaRepository = businessAreaRepository;
            _mapper = mapper;
        }

        public BusinessAreaOutputDto CreateBusinessArea(string name)
        {
            var existingBusinessArea = _businessAreaRepository.GetAll()
                .FirstOrDefault(b => b.Name == name);
            if (existingBusinessArea == null)
            {
                throw new Exception("Business area already exists!");
            }

            var businessArea = new BusinessArea(name);
            _businessAreaRepository.Add(businessArea);
            return _mapper.Map<BusinessAreaOutputDto>(businessArea);
        }

        public IEnumerable<BusinessAreaOutputDto> GetAllBusinessAreas()
        {
            var businessAreas = _businessAreaRepository.GetAll();
            return _mapper.Map<IEnumerable<BusinessAreaOutputDto>>(businessAreas);
        }
    }
}
