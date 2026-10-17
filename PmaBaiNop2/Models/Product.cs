using System.ComponentModel.DataAnnotations;

namespace PmaBaiNop2.Models
{
    public partial class Product
    {
        [Display(Name = "Mã")]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
        public string Name { get; set; } = null!;

        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        public double Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải lớn hơn hoặc bằng 0")]
        public double SalePrice { get; set; }

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateOnly CreatedDate { get; set; }

        [Display(Name = "Hình ảnh")]
        [StringLength(100)]
        public string? Image { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        public string? Description { get; set; }

        [Display(Name = "Danh mục")]
        public virtual Category? Category { get; set; }
    }
}
