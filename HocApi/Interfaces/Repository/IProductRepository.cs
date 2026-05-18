using HocApi.Models;

namespace HocApi.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
    }
}
