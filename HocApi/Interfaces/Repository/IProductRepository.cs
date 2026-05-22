using HocApi.Models;

namespace HocApi.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Product product);
        Task<IEnumerable<Product>> SearchByNameAsync(string keyword);
    }
}
