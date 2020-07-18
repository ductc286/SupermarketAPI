using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.GenericRepository;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.DataAccessLayer.Repositories;
using Supperket.BLL.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supperket.BLL.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseBillDetailRepository _purchaseBillDetailRepository;
        private readonly ISaleBillDetailRepository _saleBillDetailRepository;
        public ProductBusiness(IProductRepository productRepository, IPurchaseBillDetailRepository purchaseBillDetailRepository, ISaleBillDetailRepository saleBillDetailRepository)
        {
            _productRepository = productRepository;
            _purchaseBillDetailRepository = purchaseBillDetailRepository;
            _saleBillDetailRepository = saleBillDetailRepository;
        }

        public bool Add(ProductViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var product = new Product()
            {
                ProductName = entity.ProductName,
                CategoryId = entity.CategoryId,
                SupplierId = entity.SupplierId,
                Serial = entity.Serial,
                Price = entity.Price,
                Unit = entity.Unit,
                Note = entity.Note
            };

            return _productRepository.Add(product);
        }

        public bool Delete(object id)
        {
            var entity = _productRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }
            if (_purchaseBillDetailRepository.GetAll().Any(p => p.ProductId == entity.ProductId)
                || _saleBillDetailRepository.GetAll().Any(p => p.ProductId == entity.ProductId))
            {
                return false;
            }
            return _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().OrderByDescending(p => p.ProductId).ToList();
        }

        public Supplier GetById(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var foundProduct = _productRepository.GetById(entity.ProductId);
            if (foundProduct == null)
            {
                return false;
            }
            foundProduct.ProductName = entity.ProductName;
            foundProduct.Serial = entity.Serial;
            foundProduct.SupplierId = entity.SupplierId;
            foundProduct.CategoryId = entity.CategoryId;
            foundProduct.Price = entity.Price;
            foundProduct.Sold = entity.Sold;
            foundProduct.Inventory = entity.Inventory;
            foundProduct.Unit = entity.Unit;
            foundProduct.IsActive = entity.IsActive;
            foundProduct.Note = entity.Note;

            return _productRepository.Update(foundProduct);
        }
    }
}
