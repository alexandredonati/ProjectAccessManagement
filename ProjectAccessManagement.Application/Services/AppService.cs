using AutoMapper;
using ProjectAccessManagement.Domain.Repository;
using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Enums;
using ProjectAccessManagement.Application.DTOs.App;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectAccessManagement.Application.Services
{
    public class AppService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public AppService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public AppOutputDto CreateApp(NewAppDto dto)
        {
            var existingApplication = _applicationRepository.GetAll()
                .FirstOrDefault(a => a.Name == dto.Name);
            if (existingApplication == null)
            {
                throw new Exception($"Application with name '{dto.Name}' already exists!");
            }

            if (!Enum.TryParse<AppType>(dto.Type, true, out var applicationType))
            {
                throw new Exception($"Invalid application type: '{dto.Type}'!");
            }

            var errors = new List<string>();

            var app = new App(dto.Name, applicationType);

            foreach (var moduleName in dto.ModulesNames)
            {
                try
                {
                    app.AddModule(moduleName);
                }
                catch (InvalidOperationException ex)
                {
                    errors.Add(ex.Message);
                }
            }

            _applicationRepository.Add(app);
            var result = _mapper.Map<AppOutputDto>(app);
            result.Errors = errors;
            return result;
        }

        public void DeleteApp(Guid id)
        {
            var application = _applicationRepository.GetById(id);
            if (application == null)
            {
                throw new Exception($"Application with ID '{id}' not found!");
            }
            _applicationRepository.Delete(id);
        }

        public IEnumerable<AppOutputDto> GetAllApps()
        {
            var applications = _applicationRepository.GetAll();
            return _mapper.Map<IEnumerable<AppOutputDto>>(applications);
        }

        public AppOutputDto GetAppById(Guid id)
        {
            var application = _applicationRepository.GetById(id);
            if (application == null)
            {
                throw new Exception($"Application with ID '{id}' not found!");
            }
            return _mapper.Map<AppOutputDto>(application);
        }

        public AppOutputDto AddModulesToApp(AppOutputDto dto)
        {
            var application = _applicationRepository.GetById(dto.Id);
            if (application == null)
            {
                throw new Exception($"Application with ID '{dto.Id}' not found!");
            }

            var errors = new List<string>();

            foreach (var module in dto.AppModules)
            {
                try
                {
                    application.AddModule(module.Name);
                }
                catch (Exception ex)
                {
                    errors.Add($"Error adding module: {ex.Message}");
                }
            }
            _applicationRepository.Update(application);
            return _mapper.Map<AppOutputDto>(application);
        }

        public AppOutputDto RemoveModulesFromApp(AppModulesDto dto)
        {
            var application = _applicationRepository.GetById(dto.Id);
            if (application == null)
            {
                throw new Exception($"Application with ID '{dto.Id}' not found!");
            }

            var errors = new List<string>();

            foreach (var moduleName in dto.ModulesNames)
            {
                try
                {
                    application.RemoveModule(moduleName);
                }
                catch (Exception ex)
                {
                    errors.Add($"Error removing module: {ex.Message}");
                }
            }
            _applicationRepository.Update(application);
            var result = _mapper.Map<AppOutputDto>(application);
            result.Errors = errors;
            return result;
        }
    }
}
