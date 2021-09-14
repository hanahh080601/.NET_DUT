using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT3_102190161_LêHoàngNgọcHân.DTO;
using BT3_102190161_LêHoàngNgọcHân.DAL;

namespace BT3_102190161_LêHoàngNgọcHân.BLL
{
    class BLL_QLSV
    {
        public static BLL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance;
            }
            private set
            {
            }
        }
        private static BLL_QLSV _Instance;

        public delegate bool Compare(SV s1, SV s2);
        public Compare cmp;

        public List<SV> getListSV_BLL()
        {
            return DAL_QLSV.Instance.getListSV_DAL();
        }

        public SVView get1SVView(SV s)
        {
            SVView sv = new SVView();
            sv.MSSV = s.MSSV;
            sv.Name = s.Name;
            sv.NS = s.NS;
            sv.Gender = s.Gender;
            sv.NameLop = DAL_QLSV.Instance.getNameLopByID(s.ID_Lop);
            return sv;
        }

        public List<SVView> getListSVView_BLL(int ID, string Name)
        {
            List<SVView> list = new List<SVView>();
            if (ID == 0 && Name == "")
            {
                foreach (SV i in getListSV_BLL())
                {
                    list.Add(get1SVView(i));
                }
            }
            else
            {
                foreach (SV i in getSVByNameAndIDLop_BLL(Name, ID))
                {
                    list.Add(get1SVView(i));
                }
            }
            return list;
        }

        public SV getSVByMSSV(string mssv)
        {
            return DAL_QLSV.Instance.getSVByMSSV_DAL(mssv);
        }

        public List<SV> getSVByNameAndIDLop_BLL(string name, int id)
        {
            return DAL_QLSV.Instance.getSVByNameAndIDLop(name, id);
        }
        public void AddSVBLL(SV s)
        {
            DAL_QLSV.Instance.AddSVDAL(s);
        }

        public List<SV> GetListSVDGV(List<string> LMSSV)
        {
            List<SV> data = new List<SV>();
            foreach (string i in LMSSV)
            {
                data.Add(DAL_QLSV.Instance.getSVByMSSV_DAL(i));
            }
            return data;
        }

        public List<LopSH> GetListLSH_BLL()
        {
            return DAL_QLSV.Instance.getListLSH_DAL();
        }

        public List<string> GetListColSV()
        {
            return DAL_QLSV.Instance.getColTableSV();
        }

        public void EditSVBLL(SV s)
        {
            DAL_QLSV.Instance.EditSVDAL(s);
        }

        public void DeleteSV_BLL(string mssv)
        {
            DAL_QLSV.Instance.DeleteSV_DAL(mssv);
        }

        public List<SVView> SortSV_BLL(List<string> lmssv, int IndexCol)
        {
            switch (IndexCol)
            {
                case 0:
                    cmp = SV.CompareMSSV;
                    break;
                case 1:
                    cmp = SV.CompareNameSV;
                    break;
                case 2:
                    cmp = SV.CompareGender;
                    break;
                case 3:
                    cmp = SV.CompareNS;
                    break;
                default:
                    cmp = SV.CompareIDLop;
                    break;
            }
            List<SV> list = GetListSVDGV(lmssv);
            List<SVView> listView = new List<SVView>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        SV temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            foreach(SV i in list)
            {
                listView.Add(get1SVView(i));
            }
            return listView;
        }
    }
}

