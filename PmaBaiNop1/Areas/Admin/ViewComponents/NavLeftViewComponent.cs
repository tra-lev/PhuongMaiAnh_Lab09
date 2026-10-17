using Microsoft.AspNetCore.Mvc;
using PmaBaiNop1.Areas.Admin.Models;

namespace PmaBaiNop1.Areas.Admin.ViewComponents
{
    public class NavLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menu = new List<PmaMenuItem>
            {
                new PmaMenuItem { Title = "Trang chủ", Controller = "Dashboard", Icon = "fas fa-tachometer-alt" },
                new PmaMenuItem { Title = "Danh mục",  Controller = "Category",  Icon = "fas fa-list" },
                new PmaMenuItem { Title = "Sản phẩm",  Controller = "Product",   Icon = "fas fa-box" },
                new PmaMenuItem { Title = "Banner",    Controller = "Banner",    Icon = "fas fa-images" },
                new PmaMenuItem { Title = "Bài viết",  Controller = "Blog",      Icon = "fas fa-newspaper" }
            };
            return View(menu);
        }
    }
}
