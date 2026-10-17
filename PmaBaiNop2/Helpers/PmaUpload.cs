namespace PmaBaiNop2.Helpers
{
    public static class PmaUpload
    {
        public static async Task<string?> SaveAsync(IFormFile? file, IWebHostEnvironment env, string folder)
        {
            if (file == null || file.Length == 0) return null;
            var dir = Path.Combine(env.WebRootPath, "images", folder);
            Directory.CreateDirectory(dir);
            var fileName = Guid.NewGuid().ToString("N")[..12] + Path.GetExtension(file.FileName).ToLower();
            using (var stream = new FileStream(Path.Combine(dir, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/images/{folder}/{fileName}";
        }

        public static bool IsImage(IFormFile? file)
        {
            if (file == null) return true;
            var ext = Path.GetExtension(file.FileName).ToLower();
            return new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" }.Contains(ext);
        }
    }
}
