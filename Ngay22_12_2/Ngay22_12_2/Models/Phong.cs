namespace Ngay22_12_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        [StringLength(10)]
        public string Maphong { get; set; }

        [StringLength(50)]
        public string Tenphong { get; set; }
    }
}
