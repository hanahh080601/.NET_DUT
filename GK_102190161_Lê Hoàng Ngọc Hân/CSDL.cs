using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GK_102190161_Lê_Hoàng_Ngọc_Hân
{
    class CSDL
    {
        public DataTable DTGV { get; set; }
        public DataTable DTCS { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set
            {
            }
        }
        private static CSDL _Instance;

        private CSDL()
        {
            DTGV = new DataTable();
            DTGV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSGV", typeof(int)),
                new DataColumn("NameGV", typeof(string)),
                new DataColumn("SDT", typeof(string)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_CS", typeof(string)),
            });

            DataRow dr = DTGV.NewRow();
            dr["MSGV"] = 1;
            dr["NameGV"] = "NVA";
            dr["SDT"] = "0905900312";
            dr["NS"] = DateTime.Now;
            dr["ID_CS"] = "10001";
            DTGV.Rows.Add(dr);

            DataRow dr1 = DTGV.NewRow();
            dr1["MSGV"] = 2;
            dr1["NameGV"] = "NVB";
            dr1["SDT"] = "0905900313";
            dr1["NS"] = DateTime.Now;
            dr1["ID_CS"] = "10002";
            DTGV.Rows.Add(dr1);

            DataRow dr2 = DTGV.NewRow();
            dr2["MSGV"] = 3;
            dr2["NameGV"] = "NVC";
            dr2["SDT"] = "0905900310";
            dr2["NS"] = DateTime.Now;
            dr2["ID_CS"] = "10003";
            DTGV.Rows.Add(dr2);

            DataRow dr3 = DTGV.NewRow();
            dr3["MSGV"] = 4;
            dr3["NameGV"] = "NVD";
            dr3["SDT"] = "0905900314";
            dr3["NS"] = DateTime.Now;
            dr3["ID_CS"] = "10004";
            DTGV.Rows.Add(dr3);

            DataRow dr4 = DTGV.NewRow();
            dr4["MSGV"] = 5;
            dr4["NameGV"] = "NVE";
            dr4["SDT"] = "0905900316";
            dr4["NS"] = DateTime.Now;
            dr4["ID_CS"] = "10003";
            DTGV.Rows.Add(dr4);



            DTCS = new DataTable();
            DTCS.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_CS", typeof(int)),
                new DataColumn("NameCS", typeof(string)),
                new DataColumn("SLGV", typeof(int)),
            });

            DataRow dr5 = DTCS.NewRow();
            dr5["ID_CS"] = "10001";
            dr5["NameCS"] = "CS1";
            dr5["SLGV"] = 10;
            DTCS.Rows.Add(dr5);

            DataRow dr6 = DTCS.NewRow();
            dr6["ID_CS"] = "10002";
            dr6["NameCS"] = "CS2";
            dr6["SLGV"] = 15;
            DTCS.Rows.Add(dr6);

            DataRow dr7 = DTCS.NewRow();
            dr7["ID_CS"] = "10003";
            dr7["NameCS"] = "CS3";
            dr7["SLGV"] = 5;
            DTCS.Rows.Add(dr7);

            DataRow dr8 = DTCS.NewRow();
            dr8["ID_CS"] = "10004";
            dr8["NameCS"] = "CS4";
            dr8["SLGV"] = 2;
            DTCS.Rows.Add(dr8);
        }
    }
}
