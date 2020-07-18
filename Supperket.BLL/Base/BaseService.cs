using SupermarketAPI.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supperket.BLL.Base
{
    public class BaseService
    {
        protected readonly MyDBContext _db;

        public BaseService()
        {
        }
        public BaseService(MyDBContext db)
        {
            _db = db;
        }
    }
}
