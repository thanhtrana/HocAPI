using HocApi.Data;
using HocApi.Interfaces.Repository;
using HocApi.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool>DeleteAsync(int id){
            var product = await _context.Products.FindAsync(id);
            //FindAsync : là phương thức của Entity Framework tìm kiếm bản ghi dựa vào khoá chính 
            // hoặc tổ hợp các thuộc tính được cấu hình làm khoá chính
            // TRẢ VỀ BẢN GHI TÌM ĐƯỢC HOẶC NULL NẾU KHÔNG TÌM THẤY.
            // NÓ SẼ CỐ GẮNG TÌM TRONG DB CONTEXT THAY VÌ GỌI DB
            if(product == null){
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;

        }

    }
}
