using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DTO;
using MVC.DAL;

namespace MVC.BLL
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
            foreach(string i in LMSSV)
            {
                data.Add(DAL_QLSV.Instance.getSVByMSSV_DAL(i));
            }
            return data;
        }

        public List<LSH> GetListLSH_BLL()
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

        public List<SV> SortSV_BLL(List<string> lmssv, int IndexCol)
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
            for (int i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if(cmp(list[i], list[j]))
                    {
                        SV temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }    
            }
            return list;
        }
    }
}
