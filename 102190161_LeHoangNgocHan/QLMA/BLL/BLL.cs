using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLMA;

namespace QLMA
{
    public class BLL
    {
        QLMA db = new QLMA();
        public static BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL();
                }
                return _Instance;
            }
            private set { }
        }

        private static BLL _Instance;
        public List<NguyenLieu> GetListMANL(int ID, string Name)
        {
            List<NguyenLieu> list = new List<NguyenLieu>();
            if (ID == 0 && Name == "")
            {
                var l = from p in db.NLs select p;
                list = l.ToList();
            }
            else if (ID == 0 && Name != "")
            {
                var l = from p in db.NLs
                        where (p.TenNguyenLieu.ToUpper().Contains(Name.ToUpper()))
                        select p;
                list = l.ToList();
            }
            else
            {
                if (Name == "")
                {
                    var l = from p in db.NLs
                            where p.MaNguyenLieu == ID
                            select p;
                    list = l.ToList();
                }
                else
                {
                    var l = from p in db.NLs
                            where (p.MaNguyenLieu == ID && p.TenNguyenLieu.ToUpper().Contains(Name.ToUpper()))
                            select p;
                    list = l.ToList();
                }
            }
            return list;
        }

        public List<MonAn_NguyenLieu> GetListMANLByMMAAndInput(int mma, string input)
        {
            List<MonAn_NguyenLieu> list = new List<MonAn_NguyenLieu>();
            if (input != "" && mma == 0)
            {
                list = (from s in db.MA_NLs
                          where s.NguyenLieu.TenNguyenLieu.Contains(input)
                          select s).ToList();
            }
            else if (mma != 0)
            {
                list = (from s in db.MA_NLs
                          where s.NguyenLieu.TenNguyenLieu.Contains(input) && s.MonAn.MaMonAn == mma
                          select s).ToList();
            }
            else
            {
                list = (from s in db.MA_NLs
                          where s.MonAn.MaMonAn == mma
                          select s).ToList();
            }
            return list;
        }

        public void DeleteMANL(string id)
        {
            MonAn_NguyenLieu s = db.MA_NLs.Find(id);
            db.MA_NLs.Remove(s);
            db.SaveChanges();
        }

        public MonAn_NguyenLieu GetMANLByMa(string id)
        {
            if (db.MA_NLs.Find(id).Ma == null)
            {
                throw new Exception("MonAn_NguyenLieu không tồn tại!");
            }
            else return db.MA_NLs.Find(id);
        }

        public NguyenLieu GetNLByID(int id)
        {
            if (db.NLs.Find(id).MaNguyenLieu == null)
            {
                throw new Exception("NguyenLieu không tồn tại!");
            }
            else return db.NLs.Find(id);
        }
        public MonAn GetMAByID(int id)
        {
            if (db.MAs.Find(id).MaMonAn == null)
            {
                throw new Exception("Mon an không tồn tại!");
            }
            else return db.MAs.Find(id);
        }

        public List<MonAn_NguyenLieu> GetListMANLDGV(List<string> LMA)
        {
            List<MonAn_NguyenLieu> list = new List<MonAn_NguyenLieu>();
            foreach (string i in LMA)
            {
                list.Add(GetMANLByMa(i));
            }
            return list;
        }

        public int GetMNLByTNL(string TNL)
        {
            foreach(NguyenLieu i in db.NLs)
            {
                if (TNL == i.TenNguyenLieu) return i.MaNguyenLieu;                  
            }
            return -1;
        }

        public MonAn_NguyenLieu ConvertToMANL(string ma, int sl, string dvt, int mma, NguyenLieu nl)
        {
            MonAn_NguyenLieu manl = new MonAn_NguyenLieu();
            manl.Ma = ma;
            manl.SoLuong = sl;
            manl.DonViTinh = dvt;
            manl.MaMonAn = mma;
            manl.MaNguyenLieu = GetMNLByTNL(nl.TenNguyenLieu);
            return manl;
        }

        public void UpdateNL(NguyenLieu nl)
        {
            NguyenLieu temp = db.NLs.Find(nl.MaNguyenLieu);
            temp.TenNguyenLieu = nl.TenNguyenLieu;
            temp.TinhTrang = nl.TinhTrang;
            db.SaveChanges();
        }

        public void AddMANL(MonAn_NguyenLieu manl)
        {
            db.MA_NLs.Add(manl);
            db.SaveChanges();
        }


        public void UpdateMANL(MonAn_NguyenLieu manl)
        {
            MonAn_NguyenLieu temp = db.MA_NLs.Find(manl.Ma);
            temp.DonViTinh = manl.DonViTinh;
            temp.MaMonAn = manl.MaMonAn;
            db.SaveChanges();
        }

        public List<string> GetDVT(List<MonAn_NguyenLieu> lmanl)
        {
            var l = (from p in lmanl select p.DonViTinh).Distinct().ToList();
            return l;
        }

        public List<string> GetTNL(List<NguyenLieu> lnl)
        {
            var l = (from p in lnl select p.TenNguyenLieu).Distinct().ToList();
            return l;
        }

        public List<MonAn_NguyenLieu> SortSV(List<string> LMA, string Col)
        {
            List<MonAn_NguyenLieu> list = new List<MonAn_NguyenLieu>();
            switch (Col)
            {
                case "TenNguyenLieu":
                    list = (from s in GetListMANLDGV(LMA)
                              orderby s.NguyenLieu.TenNguyenLieu
                              select s).ToList();
                    break;
                case "SoLuong":
                    list = (from s in GetListMANLDGV(LMA)
                              orderby s.SoLuong
                              select s).ToList();
                    break;
                case "DonViTinh":
                    list = (from s in GetListMANLDGV(LMA)
                              orderby s.DonViTinh
                              select s).ToList();
                    break;
                case "TinhTrang":
                    list = (from s in GetListMANLDGV(LMA)
                              orderby s.NguyenLieu.TinhTrang
                              select s).ToList();
                    break;
            }
            return list;
        }

    }
}
