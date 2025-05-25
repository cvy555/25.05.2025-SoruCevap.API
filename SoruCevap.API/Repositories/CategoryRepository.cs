using SoruCevap.API.Models;
using SoruCevap.Repositories;

namespace SoruCevap.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}