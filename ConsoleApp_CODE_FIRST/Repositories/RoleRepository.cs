using ConsoleApp.Contexts;
using ConsoleApp.Entities;

namespace ConsoleApp_CODE_FIRST.Repositories
{
    internal class RoleRepository : Repo<RoleEntity>
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }
    }
}
