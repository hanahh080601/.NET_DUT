using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMA
{
    [Table("MonAn_NguyenLieu")]
    public class MonAn_NguyenLieu
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(5)]
        public string Ma { get; set; }
        public int SoLuong { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string DonViTinh { get; set; }
        public int MaMonAn { get; set; }
        public int MaNguyenLieu { get; set; }
        [ForeignKey("MaMonAn")]
        public virtual MonAn MonAn { get; set; }

        [ForeignKey("MaNguyenLieu")]
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
