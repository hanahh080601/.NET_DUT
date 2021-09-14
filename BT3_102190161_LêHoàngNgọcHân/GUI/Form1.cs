using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BT3_102190161_LêHoàngNgọcHân.BLL;
using BT3_102190161_LêHoàngNgọcHân.DAL;
using BT3_102190161_LêHoàngNgọcHân.DTO;

namespace BT3_102190161_LêHoàngNgọcHân.GUI
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

        private void SetCBBLSH()
        {
            cbbLSH.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (LopSH i in DAL_QLSV.Instance.getListLSH_DAL())
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
            List<string> listCol = BLL_QLSV.Instance.GetListColSV();
            for (int i = 0; i < listCol.Count; i++)
            {
                comboBox2.Items.Add(new CBBItem
                {
                    Value = i,
                    Text = listCol[i].ToString()
                });
            }
            comboBox2.SelectedIndex = 0;
        }

        public void ShowDGV()
        {
            int id = ((CBBItem)cbbLSH.SelectedItem).Value;
            if (id == 0)
            {
                dataGridView1.DataSource = BLL_QLSV.Instance.getListSVView_BLL(0, "");
            }
            else
            {
                dataGridView1.DataSource = BLL_QLSV.Instance.getListSVView_BLL(id, "");
            }
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            List<string> lmssv = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lmssv.Add(dataGridView1.Rows[i].Cells["MSSV"].Value.ToString());
            }
            dataGridView1.DataSource = BLL_QLSV.Instance.SortSV_BLL(lmssv, ((CBBItem)comboBox2.SelectedItem).Value);
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

        private void butDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow i in r)
            {
                BLL_QLSV.Instance.DeleteSV_BLL(i.Cells["MSSV"].Value.ToString());
            }
            ShowDGV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") ShowDGV();
            else
            {
                dataGridView1.DataSource = BLL_QLSV.Instance.getListSVView_BLL
                    (((CBBItem)cbbLSH.SelectedItem).Value, textBox1.Text);
            }
        }
    }
}
