using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PmaBaiNop2.Helpers;
using PmaBaiNop2.Models;

namespace PmaBaiNop2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PmaBaiNop2DbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(PmaBaiNop2DbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Categories.OrderByDescending(x => x.Id).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Status,Description")] Category model, IFormFile? ImageFile)
        {
            if (await _context.Categories.AnyAsync(x => x.Name == model.Name))
                ModelState.AddModelError("Name", "Tên này đã tồn tại");
            if (!PmaUpload.IsImage(ImageFile))
                ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh (jpg, jpeg, png, gif, webp)");

            if (ModelState.IsValid)
            {
                model.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
                model.Image = await PmaUpload.SaveAsync(ImageFile, _env, "categories");
                _context.Categories.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm mới thành công";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Categories.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Description")] Category model, IFormFile? ImageFile)
        {
            if (id != model.Id) return NotFound();
            var item = await _context.Categories.FindAsync(id);
            if (item == null) return NotFound();

            if (await _context.Categories.AnyAsync(x => x.Name == model.Name && x.Id != id))
                ModelState.AddModelError("Name", "Tên này đã tồn tại");
            if (!PmaUpload.IsImage(ImageFile))
                ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh (jpg, jpeg, png, gif, webp)");

            if (ModelState.IsValid)
            {
                item.Name = model.Name;
                item.Status = model.Status;
                item.Description = model.Description;
                var image = await PmaUpload.SaveAsync(ImageFile, _env, "categories");
                if (image != null) item.Image = image;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            model.Image = item.Image;
            model.CreatedDate = item.CreatedDate;
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Categories.FindAsync(id);
            if (item == null) return RedirectToAction(nameof(Index));
            try
            {
                _context.Categories.Remove(item);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Xóa thành công";
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "Không thể xóa vì danh mục này đang có dữ liệu liên quan.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
