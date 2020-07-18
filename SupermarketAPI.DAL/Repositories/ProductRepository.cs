using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;

namespace SupermarketAPI.DataAccessLayer.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MyDBContext db) : base(db)
        {

        }
    }

}
