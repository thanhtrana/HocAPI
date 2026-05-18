using HocApi.Interfaces.Repository;
using HocApi.Interfaces.Service;
using HocApi.Models;
using HocApi.ViewModels;

namespace HocApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductAsync(ProductViewModel model)
        {

            if (string.IsNullOrEmpty(model.Name)){
                return false;
            }


            var newProduct = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity
            };
            await _productRepository.AddAsync(newProduct);
            return true;



        }



    }
}
