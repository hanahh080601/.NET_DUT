using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_102190161_Lê_Hoàng_Ngọc_Hân
{
    public partial class Form1 : Form
    {
        public void Show()
        {
            dataGridView1.DataSource = null;
            if (cbb_CS.SelectedItem.ToString() == "All")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.DBGV;
            }
            else
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.getGVByIDCS(((CBBItem)cbb_CS.SelectedItem).Value);
            }
        }

        public Form1()
        {
            InitializeComponent();
            SetCBBCS();
            setCBBSort();
        }

        //Set comboBox cơ sở
        public void SetCBBCS()
        {
            cbb_CS.Items.Add(new CBBItem { Value = "0", Text = "All" });
            foreach (CS i in CSDL_OOP.Instance.DBCS)
            {
                cbb_CS.Items.Add(new CBBItem
                {
                    Value = i.ID_CS,
                    Text = i.NameCS
                });
            }
            cbb_CS.SelectedIndex = 0;
        }

        // Set comboBox sort
        public void setCBBSort()
        {
            for (int i = 0; i < CSDL_OOP.Instance.listName.Length; i++)
            {
                cbb_sort.Items.Add(new CBBItem
                {
                    Text = CSDL_OOP.Instance.listName[i],
                    Value = i.ToString()
                });
            }
            cbb_sort.SelectedIndex = 0;
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            Show();   
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.d(-1);
            f.ld = Show;
            f.Show();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count > 1 || r.Count == 0)
            {
                MessageBox.Show("Chọn một giảng viên để edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow dr = dataGridView1.CurrentRow;
            int index = CSDL_OOP.Instance.IndexOfGV(Convert.ToInt32(dr.Cells["MSGV"].Value));
            Form2 f = new Form2();
            f.d(index);
            f.ld = Show;
            f.Show();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn giảng viên để xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow i in r)
            {
                CSDL_OOP.Instance.DeleteGVToCSDL(Convert.ToInt32(i.Cells["MSGV"].Value));
            }
            dataGridView1.DataSource = CSDL_OOP.Instance.DBGV;
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            Sort();
        }

        public void Sort()
        {
            dataGridView1.DataSource = null;
            List<GV> list;
            if (((CBBItem)cbb_CS.SelectedItem).Value == "0")
            {
                list = CSDL_OOP.Instance.DBGV;
            }
            else
            {
                list = CSDL_OOP.Instance.getGVByIDCS(((CBBItem)cbb_CS.SelectedItem).Value.ToString());
            }
            switch (Convert.ToInt32(((CBBItem)cbb_sort.SelectedItem).Value))
            {
                case 0:
                    CSDL_OOP.Instance.Sort(list, GV.CompareIDGV);
                    break;
                case 1:
                    CSDL_OOP.Instance.Sort(list, GV.CompareTen);
                    break;
                case 2:
                    CSDL_OOP.Instance.Sort(list, GV.CompareSDT);
                    break;
                case 3:
                    CSDL_OOP.Instance.Sort(list, GV.CompareNS);
                    break;
                case 4:
                    CSDL_OOP.Instance.Sort(list, GV.CompareIDCS);
                    break;
            }
            dataGridView1.DataSource = list;
        }

        // Tìm kiếm GV theo từng kí tự
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = cbb_CS.SelectedItem.ToString();
            string id = CSDL_OOP.Instance.getIDCSByName(s);
            string name = textBox1.Text.ToString();
            if (name == "")
            {
                Show();
            }
            else if (s == "All")
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.getGVByName(name);
            }
            else
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.SearchGV(id, name);
            }
        }
    }
}
