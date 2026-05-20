namespace HocApi.ViewModels.Product
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 kí tự.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Giá sản phẩm không được để trống.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 0.")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng sản phẩm phải lớn hơn hoặc bằng 0.")]
        public int Quantity { get; set; }
    }
}
