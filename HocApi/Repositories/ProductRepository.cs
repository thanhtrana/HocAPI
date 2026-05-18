using HocApi.Data;
using HocApi.Interfaces.Repository;
using HocApi.Models;

namespace HocApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Db _context;

        public ProductRepository(Db context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
           
        }

    }
}
