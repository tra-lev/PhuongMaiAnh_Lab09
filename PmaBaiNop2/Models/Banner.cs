using System.ComponentModel.DataAnnotations;

namespace PmaBaiNop2.Models
{
    public partial class Banner
    {
        [Display(Name = "Mã")]
        public int Id { get; set; }

        [Display(Name = "Tên banner")]
        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(100, ErrorMessage = "Tên banner tối đa 100 ký tự")]
        public string Name { get; set; } = null!;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Thứ tự ưu tiên")]
        [Range(0, int.MaxValue, ErrorMessage = "Thứ tự ưu tiên phải lớn hơn hoặc bằng 0")]
        public int Priority { get; set; }

        [Display(Name = "Hình ảnh")]
        [StringLength(100)]
        public string? Image { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        public string? Description { get; set; }
    }
}
