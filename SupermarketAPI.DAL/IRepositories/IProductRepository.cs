﻿using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL.GenericRepository;

namespace SupermarketAPI.DataAccessLayer.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }

}
