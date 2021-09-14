using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class BLL
    {
        QLSVEntities1 db = new QLSVEntities1();
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
            private set
            {
            }
        }
        private static BLL _Instance;

        public List<SV> getListSV()
        {
            return db.SVs.ToList();
        }

        public SV getSVByMSSV(string id)
        {
            if (db.SVs.Find(id) == null)
            {
                throw new Exception("MSSV không tồn tại!");
            }
            else return db.SVs.Find(id);
        }

        public List<SV> GetListSVDGV(List<string> LMSSV)
        {
            List<SV> data = new List<SV>();
            foreach (string i in LMSSV)
            {
                data.Add(getSVByMSSV(i));
            }
            return data;
        }

        public void addSV(SV s)
        {
            db.SVs.Add(s);
            db.SaveChanges();
        }

        public void editSV(SV s)
        {
            SV temp = db.SVs.Find(s.MSSV);
            temp.NameSV = s.NameSV;
            temp.Gender = s.Gender;
            temp.NS = s.NS;
            temp.ID_Lop = s.ID_Lop;
            db.SaveChanges();
        }

        public List<SV> sortSV(List<string> lmssvm, int IndexCol)
        {
            List<SV> list = new List<SV>();
            switch (IndexCol)
            {
                case 0:
                    list = (from s in GetListSVDGV(lmssvm)
                            orderby s.MSSV
                            select s).ToList();
                    break;
                case 1:
                    list = (from s in GetListSVDGV(lmssvm)
                            orderby s.NameSV
                            select s).ToList();
                    break;
                case 2:
                    list = (from s in GetListSVDGV(lmssvm)
                            orderby s.Gender
                            select s).ToList();
                    break;
                case 3:
                    list = (from s in GetListSVDGV(lmssvm)
                            orderby s.NS
                            select s).ToList();
                    break;
                default:
                    list = (from s in GetListSVDGV(lmssvm)
                            orderby s.ID_Lop
                            select s).ToList();
                    break;
            }
            return list;
        }

        public void deleteSV(string id)
        {
            SV s = db.SVs.Find(id);
            db.SVs.Remove(s);
            db.SaveChanges();
        }


        public List<SV> getSVByNameAndIDLop(string name, int id)
        {
            List<SV> list = new List<SV>();
            if (id == 0 && name != "")
            {
                list = (from s in db.SVs
                        where s.NameSV.Contains(name)
                        select s).ToList();
            }
            else if(id != 0)
            {
                list = (from s in db.SVs
                        where s.NameSV.Contains(name) && s.ID_Lop == id
                        select s).ToList();
            }
            else
            {
                list = (from s in db.SVs
                        where s.ID_Lop == id
                        select s).ToList();
            }
            return list;
        }




    }
}
