using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCodeFirstPractice.DTO;
using EFCodeFirstPractice;

namespace EFCodeFirstPractice.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBBLSH();
            SetCBBSort();
            ShowDGV();
            dataGridView1.Columns[0].Visible = false;
        }
        QLSV db = new QLSV();
        
        public void SetCBBLSH()
        {
            cbbLSH.Items.Add(new CBBItem { Text = "All", Value = 0 });
            foreach(LSH i in db.LSHes)
            {
                cbbLSH.Items.Add(new CBBItem { Text = i.NameLop, Value = i.ID_Lop });
            }
            cbbLSH.SelectedIndex = 0;
        }

        public void SetCBBSort()
        {
            var columnnames = (from s in typeof(SV).GetProperties() select s.Name);
            int index = 0;
            foreach(string i in columnnames)
            {
                if (i == "LSH") break;
                cbbSort.Items.Add(new CBBItem { Text = i, Value = index });
                index += 1;
            }
        }

        public void ShowDGV()
        {
            int index = ((CBBItem)cbbLSH.SelectedItem).Value;
            if(index == 0)
            {
                var l = from s in BLL.Instance.GetListSV()
                        select new{ s.MSSV, s.NameSV, s.NS, s.Gender, s.LSH.NameLop};
                dataGridView1.DataSource = l.ToList();
            }    
            else
            {
                var l = from s in BLL.Instance.GetSVByNameAndIdLop("", index)
                        select new { s.MSSV, s.NameSV, s.NS, s.Gender, s.LSH.NameLop };
                dataGridView1.DataSource = l.ToList();
            }    
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            List<string> lmssv = new List<string>();
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lmssv.Add(dataGridView1.Rows[i].Cells["MSSV"].Value.ToString());
            }
            var l = from s in BLL.Instance.SortSV(lmssv, ((CBBItem)cbbSort.SelectedItem).Value)
                    select new { s.MSSV, s.NameSV, s.NS, s.Gender, s.LSH.NameLop };
            dataGridView1.DataSource = l.ToList();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.d("");
            f2.ld = ShowDGV;
            f2.Show();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if(r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn edit!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            else if(r.Count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form2 f2 = new Form2();
            f2.d(dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString());
            f2.ld = ShowDGV;
            f2.Show();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sinh viên muốn xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for(int i = 0; i < r.Count; i++)
            {
                string id = dataGridView1.SelectedRows[i].Cells["MSSV"].Value.ToString();
                BLL.Instance.DeleteSV(id);
                ShowDGV();
            }    
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtboxSearch.Text.ToString() == "") ShowDGV();
            else
            {
                string name = txtboxSearch.Text.ToString();
                int id = ((CBBItem)cbbLSH.SelectedItem).Value;
                var l = from s in BLL.Instance.GetSVByNameAndIdLop(name, id)
                        select new { s.MSSV, s.NameSV, s.NS, s.Gender, s.LSH.NameLop };
                dataGridView1.DataSource = l.ToList();
            }                
        }
    }
}
