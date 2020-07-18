using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;

namespace SupermarketAPI.DataAccessLayer.Repositories
{
    public class PurchaseBillRepository : GenericRepository<PurchaseBill>, IPurchaseBillRepository
    {
        public PurchaseBillRepository(MyDBContext db) : base(db)
        {

        }
    }

}
