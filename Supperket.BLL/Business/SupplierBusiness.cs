using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DataAccessLayer.IRepositories;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;
using System.Linq;

namespace Supperket.BLL.Business
{
    /// <summary>
    /// Logical processing, interacting with views and models, the main object is Supplier
    /// </summary>
    public class SupplierBusiness : ISupplierBusiness
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseBillRepository _purchaseBillRepository;
        public SupplierBusiness(ISupplierRepository supplierRepository, IProductRepository productRepository, IPurchaseBillRepository purchaseBillRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _purchaseBillRepository = purchaseBillRepository;
        }

        public bool Add(SupplierViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var supplier = new Supplier()
            {
                SupplierName = entity.SupplierName,
                Description = entity.Description
            };

            return _supplierRepository.Add(supplier);
        }

        public bool Delete(object id)
        {
            var entity = _supplierRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }
            if (_productRepository.GetAll().Any(p => p.SupplierId == entity.SupplierId)
                || _purchaseBillRepository.GetAll().Any(p => p.SupplierId == entity.SupplierId))
            {
                return false;
            }
            return _supplierRepository.Delete(entity);
        }


        public Supplier GetById(object id)
        {
            return _supplierRepository.GetById(id);
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll().OrderByDescending(s => s.SupplierId).ToList();
        }

        public bool Update(SupplierViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var foundSupplier = _supplierRepository.GetById(entity.SupplierId);
            if (foundSupplier == null)
            {
                return false;
            }
            foundSupplier.SupplierName = entity.SupplierName;
            foundSupplier.Description = entity.Description;
            return _supplierRepository.Update(foundSupplier);
        }
    }
}
