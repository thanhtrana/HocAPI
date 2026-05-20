using HocApi.Interfaces.Service;
using HocApi.ViewModels;
using HocApi.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace HocApi.Controllers
{
    [ApiController]
    [Route("product")]// Đường dẫn API mặc định sẽ là:Product
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        // Kỹ thuật Dependency Injection để gọi lớp Service vào xử lý logic
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Add")]// Đường dẫn đầy đủ: POST api/product/create
        public async Task<IActionResult> CreateProduct([FromBody] AddProductViewModel model)
        {
            try
            {
                // 1. Kiểm tra xem dữ liệu Ajax gửi lên có bị trống hay lỗi định dạng không
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, message = "Dữ liệu gửi lên không đúng định dạng." });
                }
                // 2. Chuyển tiếp dữ liệu xuống tầng Service để kiểm tra logic và lưu vào SSMS
                var isSaved = await _productService.AddProductAsync(model);

                if (isSaved)
                {
                    // Trả về mã HTTP 200 OK kèm theo thông báo dạng JSON
                    return Ok(new { success = true, message = "Thêm sản phẩm thành công." });
                }

                return BadRequest(new { success = false, message = "Thêm sản phẩm thất bạt." });

            }
            catch (Exception ex)
            {
                // Nếu database bị sập hoặc có lỗi hệ thống bất ngờ, try-catch sẽ bắt được ở đây
                return StatusCode(500, new { success = false, message = "Lỗi hệ thống." + ex.Message });
            }

        }

        [HttpGet("list-service-side")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            try
            {
                var products = await _productService.GetAllProductAsync();
                return Ok(new { success = true, data = products });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi hệ thống." + ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new { success = false, message = "Id không hợp lệ" });
                }
                var isDeleted = await _productService.DeleteAsync(id);
                if (isDeleted)
                {
                    return Ok(new { success = true, message = "Xóa sản phẩm thành công." });
                }
                return BadRequest(new { success = false, message = "Xóa sản phẩm thất bại." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi hệ thống." + ex.Message });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new { success = false, message = "Id không hợp lệ" });
                }
                var product = await _productService.GetByIdAsync(id);
                if (product == null)
                {
                    return BadRequest(new { success = false, message = "Không tìm thấy sản phẩm" });
                }
                return Ok(new { success = true, data = product });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi hệ thống." + ex.Message });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> EditProductAsync(int id, [FromBody] EditProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ" });
                }
                var isUpdated = await _productService.EditProductAsync(id, model);
                if (isUpdated)
                {
                    return Ok(new { success = true, message = "Cập nhật sản phẩm thành công." });
                }
                return BadRequest(new { success = false, message = "Cập nhật sản phẩm thất bại." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi hệ thống." + ex.Message });
            }
        }



    }
}
