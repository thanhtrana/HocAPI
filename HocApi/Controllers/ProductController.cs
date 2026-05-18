using HocApi.Interfaces.Service;
using HocApi.ViewModels;
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

        [HttpPost("create")]// Đường dẫn đầy đủ: POST api/product/create
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel model)
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

    }
}
