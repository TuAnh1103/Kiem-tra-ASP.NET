using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ngay22_12_2.Models
{
    public partial class QLNhanVienDB : DbContext
    {
        public QLNhanVienDB()
            : base("name=QLNhanVienDB1")
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Manv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Maphong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.Maphong)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
