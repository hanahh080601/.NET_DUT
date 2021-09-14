using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_04_2021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ShowDS();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string query = textBox1.Text;
            //Show(query);

            string cnnstr = @"Data Source=DESKTOP-1QK42IB\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from SV where MSSV = @M";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.Add("@M", SqlDbType.NVarChar);
            cmd.Parameters["@M"].Value = textBox1.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        private void Show(string query)
        {
            string cnnstr = @"Data Source=DESKTOP-1QK42IB\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("NameSV", typeof(string)),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            });
            cnn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["MSSV"] = r["MSSV"];
                dr["NameSV"] = r["NameSV"];
                dr["Gender"] = r["Gender"];
                dr["NS"] = r["NS"];
                dr["ID_Lop"] = r["ID_Lop"];
                dt.Rows.Add(dr);
            }
            cnn.Close();
            dataGridView1.DataSource = dt;
        }

        public void ShowDS()
        {
            string cnnstr = @"Data Source=DESKTOP-1QK42IB\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from SV";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            dataGridView1.DataSource = dt;
            //dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
