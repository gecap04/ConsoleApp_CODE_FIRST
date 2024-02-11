using ConsoleApp.Contexts;
using ConsoleApp.Entities;

namespace ConsoleApp_CODE_FIRST.Repositories
{
    internal class CategoryRepository : Repo<CategoryEntity>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
