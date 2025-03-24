using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;

namespace ProjectAccessManagement.Repository.Repositories
{
    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ProjectAccessManagementContext context) : base(context)
        {
        }
    }
}
