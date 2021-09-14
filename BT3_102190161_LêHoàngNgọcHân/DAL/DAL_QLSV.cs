using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BT3_102190161_LêHoàngNgọcHân.DTO;
using System.Windows.Forms;

namespace BT3_102190161_LêHoàngNgọcHân.DAL
{
    class DAL_QLSV
    {
        public static DAL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLSV();
                }
                return _Instance;
            }
            private set
            {
            }
        }
        private static DAL_QLSV _Instance;
        public List<SV> getListSV_DAL()
        {
            List<SV> data = new List<SV>();
            string query = "select * from SV";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                data.Add(getSV(i));
            }
            return data;
        }

        public List<SV> getSVByNameAndIDLop(string name, int id)
        {
            List<SV> list = new List<SV>();
            string query = "";
            if (id == 0 && name != "")
            {
                foreach (SV i in getListSV_DAL())
                {
                    if (i.Name.ToUpper().Contains(name.ToUpper()))
                    {
                        list.Add(i);
                    }
                }
            }
            else
            {
                query = "select * from SV where ID_Lop = " + id.ToString();
                if (name == "")
                {
                    foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
                    {
                        list.Add(getSV(i));
                    }
                }
                else
                {
                    foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
                    {
                        if (i["NameSV"].ToString().ToUpper().Contains(name.ToUpper()))
                        {
                            list.Add(getSV(i));
                        }
                    }
                }
            }
            return list;
        }

        public List<LopSH> getListLSH_DAL()
        {
            List<LopSH> list = new List<LopSH>();
            string query = "select * from LopSH";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(getLSH(i));
            }
            return list;
        }

        public SV getSV(DataRow i)
        {
            SV s = new SV();
            s.MSSV = i["MSSV"].ToString();
            s.Name = i["NameSV"].ToString();
            s.Gender = Convert.ToBoolean(i["Gender"]);
            s.ID_Lop = Convert.ToInt32(i["ID_Lop"]);
            s.NS = Convert.ToDateTime(i["NS"]);
            return s;
        }

        public LopSH getLSH(DataRow i)
        {
            LopSH l = new LopSH();
            l.ID_Lop = Convert.ToInt32(i["ID_Lop"]);
            l.NameLop = i["NameLop"].ToString();
            return l;
        }


        public string getCol(DataRow i)
        {
            return (i["Tên column"].ToString());
        }

        public void AddSVDAL(SV s)
        {
            string query = "insert into SV values ('" + s.MSSV + "', N'" + s.Name + "','" + s.Gender.ToString()
                + "','" + s.NS + "'," + s.ID_Lop + ")";
            DBHelper.Instance.ExecuteDB(query);
        }

        public List<string> getColTableSV()
        {
            List<string> list = new List<string>();
            string query = "select cl.name as 'Tên column' from sys.all_columns cl join sys.types tp " +
                "on cl.user_type_id = tp.user_type_id where object_id = " +
                "(select object_id from sys.objects where type='u' and name ='SV')";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(getCol(i));
            }
            return list;
        }

        public SV getSVByMSSV_DAL(string mssv)
        {
            string query = "select * from SV where MSSV = '" + mssv + "'";
            return getSV(DBHelper.Instance.GetRecords(query).Rows[0]);
        }

        public void EditSVDAL(SV s)
        {
            string query = "update SV set NameSV = N'" + s.Name + "', Gender = '" + s.Gender.ToString() + "', NS = '"
                + s.NS + "', ID_Lop = " + s.ID_Lop + " where MSSV = '" + s.MSSV + "'";
            DBHelper.Instance.ExecuteDB(query);
        }

        public void DeleteSV_DAL(string mssv)
        {
            string query = "delete from SV where MSSV = '" + mssv + "'";
            DBHelper.Instance.ExecuteDB(query);
        }

        public string getNameLopByID(int id)
        {
            string query = "select NameLop from LopSH where ID_Lop = " + id.ToString();
            DataRow dr = DBHelper.Instance.GetRecords(query).Rows[0];
            return dr["NameLop"].ToString();
        }
    }
}
