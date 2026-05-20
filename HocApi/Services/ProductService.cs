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


        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }


        public async Task<EditProductViewModel> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }


        public async Task<bool> EditProductAsync(int id, EditProductViewModel model)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = model.Name;
            existingProduct.Price = model.Price;
            existingProduct.Quantity = model.Quantity;

            return await _productRepository.UpdateAsync(existingProduct);
        }



    }
}
