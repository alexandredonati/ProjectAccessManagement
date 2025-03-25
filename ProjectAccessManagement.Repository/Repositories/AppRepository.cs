using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;

namespace ProjectAccessManagement.Repository.Repositories
{
    public class AppRepository : BaseRepository<App>, IApplicationRepository
    {
        public AppRepository(ProjectAccessManagementContext context) : base(context)
        {
        }
    }
}
