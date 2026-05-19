using HocApi.ViewModels;
using HocApi.ViewModels.Product;

namespace HocApi.Interfaces.Service
{
    public interface IProductService
    {
        //Thêm sản phẩm mới vào hệ thống
        Task<bool> AddProductAsync(AddProductViewModel model);

        Task<IEnumerable<ViewProductViewModel>> GetAllProductAsync();
    }
}
