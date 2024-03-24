
using UnitOfWork.Domain.Entities;
using UnitOfWork.Domain.Interfaces;
using UnitOfWork.Services.Interfaces;

namespace UnitOfWork.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            if (product != null)
            {
                await _unitOfWork.Repository<Product>().Add(product);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var product = await _unitOfWork.Repository<Product>().GetById(productId);
                if (product != null)
                {
                    _unitOfWork.Repository<Product>().Delete(product);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var productList = await _unitOfWork.Repository<Product>().GetAll();
            return productList;
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var product = await _unitOfWork.Repository<Product>().GetById(productId);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (product != null)
            {
                var updateProduct = await _unitOfWork.Repository<Product>().GetById(product.Id);
                if (updateProduct != null)
                {
                    updateProduct.ProductName = product.ProductName;
                    updateProduct.ProductPrice = product.ProductPrice;
                    updateProduct.ProductStock = product.ProductStock;

                    _unitOfWork.Repository<Product>().Update(updateProduct);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
