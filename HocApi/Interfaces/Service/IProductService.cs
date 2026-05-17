using HocApi.ViewModels;

namespace HocApi.Interfaces.Service
{
    public interface IProductService 
    {
        //Thêm sản phẩm mới vào hệ thống
        Task<bool> AddProductAsync(ProductViewModel model);
    }
}
