using HocApi.ViewModels;
using HocApi.ViewModels.Product;

namespace HocApi.Interfaces.Service
{
    public interface IProductService
    {
        //Thêm sản phẩm mới vào hệ thống
        Task<bool> AddProductAsync(AddProductViewModel model);

        Task<IEnumerable<ViewProductViewModel>> GetAllProductAsync();
        Task<bool> DeleteAsync(int id);
        Task<EditProductViewModel> GetByIdAsync(int id);
        Task<bool> EditProductAsync(int id, EditProductViewModel model);



    }
}
