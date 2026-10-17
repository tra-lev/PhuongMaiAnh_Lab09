using System.ComponentModel.DataAnnotations;

namespace PmaBaiNop2.Models
{
    public partial class Blog
    {
        [Display(Name = "Mã")]
        public int Id { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100, ErrorMessage = "Tiêu đề tối đa 100 ký tự")]
        public string Name { get; set; } = null!;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Ngày tạo")]
        public DateOnly CreatedDate { get; set; }

        [Display(Name = "Hình ảnh")]
        [StringLength(100)]
        public string? Image { get; set; }

        [Display(Name = "Nội dung")]
        [StringLength(350, ErrorMessage = "Nội dung tối đa 350 ký tự")]
        public string? Description { get; set; }
    }
}
