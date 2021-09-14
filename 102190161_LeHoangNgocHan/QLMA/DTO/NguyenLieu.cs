using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMA
{
    [Table("NguyenLieu")]
    public class NguyenLieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNguyenLieu { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string TenNguyenLieu { get; set; }
        public bool TinhTrang { get; set; }
        public virtual ICollection<MonAn> MAs { get; set; }
        public NguyenLieu()
        {
            MAs = new HashSet<MonAn>();
        }

    }
}
