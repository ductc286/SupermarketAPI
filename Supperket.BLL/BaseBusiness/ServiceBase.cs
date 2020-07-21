using SupermarketAPI.DAL.Database;

namespace Supperket.BLL.BaseBusiness
{
    public abstract class ServiceBase
    {
        protected readonly MyDBContext _db;

        public ServiceBase(MyDBContext db)
        {
            _db = db;
        }
    }
}
