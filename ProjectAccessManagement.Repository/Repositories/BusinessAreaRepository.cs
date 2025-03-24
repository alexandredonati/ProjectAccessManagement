using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;

namespace ProjectAccessManagement.Repository.Repositories
{
    public class BusinessAreaRepository: BaseRepository<BusinessArea>, IBusinessAreaRepository
    {
        public BusinessAreaRepository(ProjectAccessManagementContext context) : base(context)
        {
        }
    }
}
