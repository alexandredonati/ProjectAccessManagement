using ProjectAccessManagement.Domain.Entities;

namespace ProjectAccessManagement.Domain.Repository
{
    public interface ICredentialRepository
    {
        Task<Credential> GetByIdAsync(Guid id);
        Task<IEnumerable<Credential>> GetAllAsync();
        Task AddAsync(Credential credential);
        Task UpdateAsync(Credential credential);
        Task DeleteAsync(Guid id);
    }
}
