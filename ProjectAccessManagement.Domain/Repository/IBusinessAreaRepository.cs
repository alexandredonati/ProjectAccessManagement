using ProjectAccessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAccessManagement.Domain.Repository
{
    public interface IBusinessAreaRepository
    {
        Task<BusinessArea> GetByIdAsync(Guid id);
        Task<IEnumerable<BusinessArea>> GetAllAsync();
        Task AddAsync(BusinessArea businessArea);
        Task UpdateAsync(BusinessArea businessArea);
        Task DeleteAsync(Guid id);
    }
}
