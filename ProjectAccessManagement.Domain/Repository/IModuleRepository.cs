using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Domain.Repository
{
    public interface IModuleRepository
    {
        Task<Module> GetByIdAsync(Guid id);
        Task<IEnumerable<Module>> GetAllAsync();
        Task AddAsync(Module module);
        Task UpdateAsync(Module module);
        Task DeleteAsync(Guid id);
    }
}
