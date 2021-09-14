using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPractice.DTO;

namespace EFCodeFirstPractice
{
    public class BLL
    {
        QLSV db = new QLSV();
        public static BLL Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new BLL();
                }
                return _Instance;
            }
            private set { }
        }

        private static BLL _Instance;
        public List<SV> GetListSV()
        {
            return db.SVs.ToList();
        }

        public SV GetSVByMSSV(string id)
        {
            if (db.SVs.Find(id).MSSV == null)
            {
                throw new Exception("MSSV không tồn tại!");
            }
            else return db.SVs.Find(id);
        }

        public List<SV> GetListSVDGV(List<string> LMSSV)
        {
            List<SV> listSV = new List<SV>();
            foreach(string i in LMSSV)
            {
                listSV.Add(GetSVByMSSV(i));
            }
            return listSV;
        }

        public void AddSV(SV s)
        {
            db.SVs.Add(s);
            db.SaveChanges();
        }

        public void UpdateSV(SV s)
        {
            SV temp = db.SVs.Find(s.MSSV);
            temp.NameSV = s.NameSV;
            temp.NS = s.NS;
            temp.Gender = s.Gender;
            temp.ID_Lop = s.ID_Lop;
            db.SaveChanges();
        }

        public void DeleteSV(string id)
        {
            SV s = db.SVs.Find(id);
            db.SVs.Remove(s);
            db.SaveChanges();
        }

        public List<SV> SortSV(List<string> LMSSV, int indexCol)
        {
            List<SV> listSV = new List<SV>();
            switch (indexCol)
            {
                case 0:
                    listSV = (from s in GetListSVDGV(LMSSV)
                              orderby s.MSSV
                              select s).ToList();
                    break;
                case 1:
                    listSV = (from s in GetListSVDGV(LMSSV)
                              orderby s.NameSV
                              select s).ToList();
                    break;
                case 2:
                    listSV = (from s in GetListSVDGV(LMSSV)
                              orderby s.Gender
                              select s).ToList();
                    break;
                case 3:
                    listSV = (from s in GetListSVDGV(LMSSV)
                              orderby s.NS
                              select s).ToList();
                    break;
                default:
                    listSV = (from s in GetListSVDGV(LMSSV)
                              orderby s.ID_Lop
                              select s).ToList();
                    break;
            }
            return listSV;
        }

        public List<SV> GetSVByNameAndIdLop(string name, int idlop)
        {
            List<SV> listSV = new List<SV>();
            if(name != "" && idlop == 0)
            {
                listSV = (from s in db.SVs
                          where s.NameSV.Contains(name)
                          select s).ToList();
            }    
            else if(idlop != 0)
            {
                listSV = (from s in db.SVs
                          where s.NameSV.Contains(name) && s.ID_Lop == idlop
                          select s).ToList();
            }
            else
            {
                listSV = (from s in db.SVs
                          where s.ID_Lop == idlop
                          select s).ToList();
            }
            return listSV;
        }
    }

}
