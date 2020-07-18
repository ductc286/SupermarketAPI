using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;

namespace SupermarketAPI.DataAccessLayer.Repositories
{
    public class SaleBillRepository : GenericRepository<SaleBill>, ISaleBillRepository
    {
        public SaleBillRepository(MyDBContext db) : base(db)
        {

        }
    }

}
