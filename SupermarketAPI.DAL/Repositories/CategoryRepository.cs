using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;

namespace SupermarketAPI.DataAccessLayer.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyDBContext db) : base(db)
        {

        }
    }

}
