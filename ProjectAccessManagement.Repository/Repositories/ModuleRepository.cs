using ProjectAccessManagement.Domain.Entities;
using ProjectAccessManagement.Domain.Repository;

namespace ProjectAccessManagement.Repository.Repositories
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(ProjectAccessManagementContext context) : base(context)
        {
        }
    }
}
