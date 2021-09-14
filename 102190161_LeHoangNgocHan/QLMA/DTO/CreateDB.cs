using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMA
{
    class CreateDB : DropCreateDatabaseIfModelChanges<QLMA>
    {
        protected override void Seed(QLMA context)
        {
            context.NLs.AddRange(new NguyenLieu[]
            {
                new NguyenLieu {MaNguyenLieu = 1, TenNguyenLieu = "A", TinhTrang = true},
                new NguyenLieu {MaNguyenLieu = 2, TenNguyenLieu = "B", TinhTrang = false},
                new NguyenLieu {MaNguyenLieu = 3, TenNguyenLieu = "C", TinhTrang = false},
                new NguyenLieu {MaNguyenLieu = 4, TenNguyenLieu = "D", TinhTrang = true}
            });

            context.MAs.AddRange(new MonAn[]
            {
                new MonAn {MaMonAn = 1, TenMonAn = "MA1"},
                new MonAn {MaMonAn = 2, TenMonAn = "MA2"},
                new MonAn {MaMonAn = 3, TenMonAn = "MA3"},
                new MonAn {MaMonAn = 4, TenMonAn = "MA4"},
                new MonAn {MaMonAn = 5, TenMonAn = "MA5"},
            });

            context.MA_NLs.AddRange(new MonAn_NguyenLieu[]
            {
                new MonAn_NguyenLieu {Ma = "MANL1", SoLuong = 5, DonViTinh = "gram", MaMonAn = 1, MaNguyenLieu = 1},
                new MonAn_NguyenLieu {Ma = "MANL2", SoLuong = 3, DonViTinh = "lit", MaMonAn = 2, MaNguyenLieu = 1},
                new MonAn_NguyenLieu {Ma = "MANL3", SoLuong = 2, DonViTinh = "cu", MaMonAn = 1, MaNguyenLieu = 1},
                new MonAn_NguyenLieu {Ma = "MANL4", SoLuong = 7, DonViTinh = "kg", MaMonAn = 3, MaNguyenLieu = 3},
                new MonAn_NguyenLieu {Ma = "MANL5", SoLuong = 4, DonViTinh = "lang", MaMonAn = 4, MaNguyenLieu = 3},
                new MonAn_NguyenLieu {Ma = "MANL6", SoLuong = 5, DonViTinh = "gram", MaMonAn = 1, MaNguyenLieu = 4},
                new MonAn_NguyenLieu {Ma = "MANL7", SoLuong = 3, DonViTinh = "lit", MaMonAn = 2, MaNguyenLieu = 4},
                new MonAn_NguyenLieu {Ma = "MANL8", SoLuong = 2, DonViTinh = "cu", MaMonAn = 1, MaNguyenLieu = 3},
                new MonAn_NguyenLieu {Ma = "MANL9", SoLuong = 7, DonViTinh = "kg", MaMonAn = 3, MaNguyenLieu = 3},
                new MonAn_NguyenLieu {Ma = "MANL0", SoLuong = 4, DonViTinh = "lang", MaMonAn = 4, MaNguyenLieu = 3},
                new MonAn_NguyenLieu {Ma = "MANL", SoLuong = 2, DonViTinh = "lang", MaMonAn = 1, MaNguyenLieu = 3},
            });
        }
    }
}
