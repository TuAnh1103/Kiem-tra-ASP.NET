namespace Ngay22_12_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Hoten { get; set; }

        [StringLength(10)]
        public string Maphong { get; set; }

        public double? Luong { get; set; }
    }
}
