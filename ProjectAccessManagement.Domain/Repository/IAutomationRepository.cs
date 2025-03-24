using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Domain.Repository
{
    public interface IAutomationRepository
    {
        Task<Automation> GetByIdAsync(Guid id);
        Task<IEnumerable<Automation>> GetAllAsync();
        Task AddAsync(Automation automation);
        Task UpdateAsync(Automation automation);
        Task DeleteAsync(Guid id);
    }
}
