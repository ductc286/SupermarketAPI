using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.Database;
using SupermarketAPI.DataAccessLayer.IRepositories;
using SupermarketAPI.DataAccessLayer.Repositories;
using Supperket.BLL.IBusiness;
using System.Collections.Generic;
using System.Linq;

namespace Supperket.BLL.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryBusiness(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public bool Add(CategoryViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var category = new Category()
            {
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
            return _categoryRepository.Add(category);
        }

        public bool Delete(object id)
        {
            var entity = _categoryRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }
            if (_productRepository.GetAll().Any(p => p.CategoryId == entity.CategoryId))
            {
                return false;
            }
            return _categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll().OrderByDescending(c => c.CategoryId).ToList();
        }

        public Category GetById(object id)
        {
            return _categoryRepository.GetById(id);
        }

        public bool Update(CategoryViewModel entity)
        {
            if (entity == null)
            {
                return false;
            }
            var findCategory = _categoryRepository.GetById(entity.CategoryId);
            if (findCategory == null)
            {
                return false;
            }
            findCategory.CategoryName = entity.CategoryName;
            findCategory.Description = entity.Description;
            return _categoryRepository.Update(findCategory);
        }
    }
}
