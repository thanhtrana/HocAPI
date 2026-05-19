using HocApi.Interfaces.Repository;
using HocApi.Interfaces.Service;
using HocApi.Models;
using HocApi.ViewModels;
using HocApi.ViewModels.Product;

namespace HocApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductAsync(AddProductViewModel model)
        {

            if (string.IsNullOrEmpty(model.Name))
            {
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

        public async Task<IEnumerable<ViewProductViewModel>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var propductViewModels = products.Select(p => new ViewProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity
            });

            return propductViewModels;

        }


    }
}
