using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        QLSVEntities1 db = new QLSVEntities1();
        public Form1()
        {
            InitializeComponent();
            SetCBBLSH();
            SetCBBSort();
            ShowDGV();
            dataGridView1.Columns[0].Visible = false;
        }

        private void SetCBBLSH()
        {
            cbbLSH.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (LopSH i in db.LopSHes)
            {
                cbbLSH.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
            cbbLSH.SelectedIndex = 0;
        }

        private void SetCBBSort()
        {
            var columnnames = from t in typeof(SV).GetProperties() select t.Name;
            int i = 0;
            foreach(String s in columnnames)
            {
                if (s == "LopSH") break;
                cbbSort.Items.Add(new CBBItem
                {
                    Value = i++,
                    Text = s
                });
            }    
        }

        public void ShowDGV()
        {
            int id = ((CBBItem)cbbLSH.SelectedItem).Value;
            if (id == 0)
            {
                var l = from s in BLL.Instance.getListSV()
                        select new { s.MSSV, s.NameSV, s.Gender, s.NS, s.LopSH.NameLop };
                dataGridView1.DataSource = l.ToList();
            }
            else
            {
                var l = from s in BLL.Instance.getSVByNameAndIDLop("", id)
                        select new { s.MSSV, s.NameSV, s.Gender, s.NS, s.LopSH.NameLop };
                dataGridView1.DataSource = l.ToList();
            }
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.d("");
            f2.ld = ShowDGV;
            f2.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow i in r)
            {
                BLL.Instance.deleteSV(i.Cells["MSSV"].Value.ToString());
            }
            ShowDGV();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (r.Count > 1)
            {
                MessageBox.Show("Chỉ chọn 1 sinh viên để edit!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string s = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            Form2 f2 = new Form2();
            f2.d(s);
            f2.ld = ShowDGV;
            f2.Show();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<string> lmssv = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lmssv.Add(dataGridView1.Rows[i].Cells["MSSV"].Value.ToString());
            }
            var l = from s in BLL.Instance.sortSV(lmssv, ((CBBItem)cbbSort.SelectedItem).Value)
                    select new { s.MSSV, s.NameSV, s.Gender, s.NS, s.LopSH.NameLop };
            dataGridView1.DataSource = l.ToList();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") ShowDGV();
            else
            {
                var l = from s in BLL.Instance.getSVByNameAndIDLop
                        (textBox1.Text, ((CBBItem)cbbLSH.SelectedItem).Value)
                        select new { s.MSSV, s.NameSV, s.Gender, s.NS, s.LopSH.NameLop };
                dataGridView1.DataSource = l.ToList();
            }
        }
    }
}
