using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190161_Lê_Hoàng_Ngọc_Hân
{
    class CSDL_OOP
    {
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }
            private set
            {
            }
        }
        private static CSDL_OOP _Instance;

        public string[] listName = new string[CSDL.Instance.DTGV.Columns.Count];
        public delegate bool Compare(GV s1, GV s2);
        public List<GV> DBGV;
        public List<CS> DBCS;

        private void getAllGV()
        {
            DBGV = new List<GV>();
            for (int i = 0; i < CSDL.Instance.DTGV.Rows.Count; i++)
            {
                GV temp = new GV();
                temp.MSGV = Convert.ToInt32(CSDL.Instance.DTGV.Rows[i]["MSGV"].ToString());
                temp.Name = CSDL.Instance.DTGV.Rows[i]["NameGV"].ToString();
                temp.SDT = CSDL.Instance.DTGV.Rows[i]["SDT"].ToString();
                temp.ID_CS = CSDL.Instance.DTGV.Rows[i]["ID_CS"].ToString();
                temp.NS = Convert.ToDateTime(CSDL.Instance.DTGV.Rows[i]["NS"]);
                DBGV.Add(temp);
            }
        }

        private void getAllCS()
        {
            DBCS = new List<CS>();
            for (int i = 0; i < CSDL.Instance.DTCS.Rows.Count; i++)
            {
                CS temp = new CS();
                temp.ID_CS = CSDL.Instance.DTCS.Rows[i]["ID_CS"].ToString();
                temp.NameCS = CSDL.Instance.DTCS.Rows[i]["NameCS"].ToString();
                temp.SLGV = Convert.ToInt32(CSDL.Instance.DTCS.Rows[i]["SLGV"]);//
                DBCS.Add(temp);
            }
        }

        private CSDL_OOP()
        {
            getAllGV();
            getAllCS();
            for (int i = 0; i < CSDL.Instance.DTGV.Columns.Count; i++)
            {
                listName[i] = CSDL.Instance.DTGV.Columns[i].ColumnName;
            }
        }

        public string getIDCSByName(string nameCS)
        {
            foreach (CS i in DBCS)
            {
                if (nameCS == i.NameCS) return i.ID_CS.ToString();
            }
            return "";
        }

        public string getCSByIDCS(string id)
        {
            for (int i = 0; i < CSDL_OOP.Instance.DBCS.Count; i++)
            {
                if (id == DBCS[i].ID_CS) return DBCS[i].NameCS;
            }
            return "";
        }

        public int getSLGV(string id)
        {
            for (int i = 0; i < CSDL_OOP.Instance.DBCS.Count; i++)
            {
                if (id == DBCS[i].ID_CS) return DBCS[i].SLGV;
            }
            return -1;
        }

        public List<GV> getGVByIDCS(string id)
        {
            List<GV> temp = new List<GV>();
            for (int i = 0; i < CSDL_OOP.Instance.DBGV.Count; i++)
            {
                if (id == CSDL_OOP.Instance.DBGV[i].ID_CS.ToString())
                {
                    temp.Add(DBGV[i]);
                }
            }
            return temp;
        }

        public int IndexOfGV(int msgv)
        {
            for (int i = 0; i < CSDL.Instance.DTGV.Rows.Count; i++)
            {
                if (msgv == Convert.ToInt32(CSDL.Instance.DTGV.Rows[i]["MSGV"])) return i;
            }
            return -1;
        }

        public bool CheckSLGV(string IDCS)
        {
            if (getGVByIDCS(IDCS).Count < getSLGV(IDCS))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddGVToCSDL(GV s)
        {
            DBGV.Add(s);
            DataRow dr = CSDL.Instance.DTGV.NewRow();
            dr["MSGV"] = s.MSGV;
            dr["NameGV"] = s.Name;
            dr["SDT"] = s.SDT;
            dr["ID_CS"] = s.ID_CS;
            dr["NS"] = s.NS;
            CSDL.Instance.DTGV.Rows.Add(dr);
            getAllGV();
        }

        public void EditGVToCSDL(GV s)
        {
            int index = CSDL_OOP.Instance.IndexOfGV(s.MSGV);
            DBGV[index] = s;
            CSDL.Instance.DTGV.Rows[index]["MSGV"] = s.MSGV;
            CSDL.Instance.DTGV.Rows[index]["NameGV"] = s.Name;
            CSDL.Instance.DTGV.Rows[index]["SDT"] = s.SDT;
            CSDL.Instance.DTGV.Rows[index]["ID_CS"] = s.ID_CS;
            CSDL.Instance.DTGV.Rows[index]["NS"] = s.NS;
            getAllGV();
        }

        public void DeleteGVToCSDL(int msgv)
        {
            int index = CSDL_OOP.Instance.IndexOfGV(msgv);
            CSDL_OOP.Instance.DBGV.RemoveAt(index);
            CSDL.Instance.DTGV.Rows.RemoveAt(index);
            getAllGV();
        }

        public List<GV> getGVByName(string name)
        {
            int n = CSDL_OOP.Instance.DBGV.Count;
            List<GV> l = new List<GV>();
            for (int i = 0; i < n; i++)
            {
                if (CSDL_OOP.Instance.DBGV[i].Name.Contains(name)) l.Add(DBGV[i]);
            }
            return l;
        }

        public List<GV> SearchGV(string id, string name)
        {
            List<GV> l = new List<GV>();
            List<GV> temp = CSDL_OOP.Instance.getGVByName(name);
            for (int i = 0; i < temp.Count; i++)
            {
                if (id == temp[i].ID_CS) l.Add(temp[i]);
            }
            return l;
        }

        public void Sort(List<GV> list, Compare cmp)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        GV temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
