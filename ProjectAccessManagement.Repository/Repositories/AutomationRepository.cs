using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;

namespace ProjectAccessManagement.Repository.Repositories
{
    public class AutomationRepository : BaseRepository<Automation>, IAutomationRepository
    {
        public AutomationRepository(ProjectAccessManagementContext context) : base(context)
        {
        }
    }
}
