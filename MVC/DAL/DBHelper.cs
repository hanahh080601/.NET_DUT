using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;

namespace MVC.DAL
{
    class DBHelper
    {
        private static DBHelper _Instance;

        private SqlConnection cnn;

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string cnnstr = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
                    _Instance = new DBHelper(cnnstr);
                }
                return _Instance;
            }
            private set { }
        }

        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }

        public DataTable GetRecords(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public void ExecuteDB(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
