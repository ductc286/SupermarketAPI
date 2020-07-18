using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;

namespace SupermarketAPI.DataAccessLayer.Repositories
{
    public class EndOfShiftRepository : GenericRepository<EndOfShift>, IEndOfShiftRepository
    {
        public EndOfShiftRepository(MyDBContext db) : base(db)
        {

        }
    }

}
