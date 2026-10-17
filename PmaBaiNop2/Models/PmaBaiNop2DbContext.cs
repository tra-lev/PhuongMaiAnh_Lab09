using Microsoft.EntityFrameworkCore;

namespace PmaBaiNop2.Models
{
    public partial class PmaBaiNop2DbContext : DbContext
    {
        public PmaBaiNop2DbContext()
        {
        }

        public PmaBaiNop2DbContext(DbContextOptions<PmaBaiNop2DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
