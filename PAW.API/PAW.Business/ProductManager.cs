using PAW.Models;
using PAW.Data.Repository;

namespace PAW.Business
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> CreateProduct();
    }


    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> CreateProduct() 
        {
            return await _productRepository.ReadProductsAsync();
        }
    }
}
