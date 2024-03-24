﻿using UnitOfWork.Domain.Entities;

namespace UnitOfWork.Services.Interfaces;

public interface IProductService
{
    Task<bool> CreateProduct(Product product);

    Task<IEnumerable<Product>> GetAllProducts();

    Task<Product> GetProductById(int productId);

    Task<bool> UpdateProduct(Product product);

    Task<bool> DeleteProduct(int productId);
}
