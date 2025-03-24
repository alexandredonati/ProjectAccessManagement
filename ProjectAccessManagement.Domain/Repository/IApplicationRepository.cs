using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Domain.Repository
{
    public interface IApplicationRepository
    {
        Task<Application> GetByIdAsync(Guid id);
        Task<IEnumerable<Application>> GetAllAsync();
        Task AddAsync(Application application);
        Task UpdateAsync(Application application);
        Task DeleteAsync(Guid id);
    }
}
