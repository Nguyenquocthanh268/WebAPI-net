using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet

        public DbSet<RefreshToken> RefreshTokens{ get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);

            });

            modelBuilder.Entity<DonHangChiTiet>()
                .ToTable("ChiTietDonHang")
                .HasKey(k => new { k.MaDh, k.MaHh });
            modelBuilder.Entity<DonHangChiTiet>()
                .HasOne(p => p.DonHang)
                .WithMany(p => p.DonHangChiTiets)
                .HasForeignKey(c => c.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");
            modelBuilder.Entity<DonHangChiTiet>()
                .HasOne(p => p.HangHoa)
                .WithMany(p => p.DonHangChiTiets)
                .HasForeignKey(c => c.MaHh)
                .HasConstraintName("FK_DonHangCT_HangHoa ");

            modelBuilder.Entity<NguoiDung>(e =>
            {
                e.HasIndex(e => e.UserName).IsUnique();
            });

        }
    }
}
