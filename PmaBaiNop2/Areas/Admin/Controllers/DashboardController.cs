using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PmaBaiNop2.Models;

namespace PmaBaiNop2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PmaBaiNop2DbContext _context;

        public DashboardController(PmaBaiNop2DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryCount = await _context.Categories.CountAsync();
            ViewBag.ProductCount = await _context.Products.CountAsync();
            ViewBag.BannerCount = await _context.Banners.CountAsync();
            ViewBag.BlogCount = await _context.Blogs.CountAsync();
            return View();
        }
    }
}
