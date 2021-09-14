using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLMA
{
    [Table("MonAn")]
    public class MonAn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMonAn { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string TenMonAn { get; set; }
        public virtual ICollection<NguyenLieu> NLs { get; set; }
        public MonAn()
        {
            NLs = new HashSet<NguyenLieu>();
        }
    }
}
