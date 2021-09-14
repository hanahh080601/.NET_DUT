using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBBMA();
            SetCBBSort();
            ShowDGV("");
        }

        QLMA db = new QLMA();
        private void SetCBBMA()
        {
            foreach (MonAn i in db.MAs)
            {
                cbbMA.Items.Add(new CBBItem
                {
                    Value = i.MaMonAn,
                    Text = i.TenMonAn
                });
            }
            cbbMA.SelectedIndex = 0;
        }

        private void SetCBBSort()
        {
            List<string> list = new List<string>();
            for(int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                list.Add(dataGridView1.Columns[i].Name);
            }
            int j = 0;
            foreach(string i in list)
            {
                cbbSort.Items.Add(new CBBItem
                {
                    Value = j,
                    Text = i
                });
            }    
        }

        private void ShowDGV(string str)
        {
            int index = ((CBBItem)cbbMA.SelectedItem).Value;
            var l = from s in BLL.Instance.GetListMANLByMMAAndInput(index, str)
                        select new { s.Ma, s.NguyenLieu.TenNguyenLieu, s.SoLuong, s.DonViTinh, s.NguyenLieu.TinhTrang };
            dataGridView1.DataSource = l.ToList();  
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            string input = txtboxSearch.Text;
            ShowDGV(input);
        }

        private void cbbMA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDGV("");
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 nguyên liệu muốn xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < r.Count; i++)
            {
                string id = dataGridView1.SelectedRows[i].Cells["Ma"].Value.ToString();
                MonAn_NguyenLieu manl = db.MA_NLs.Find(id);
                if(manl.NguyenLieu.TinhTrang == false)
                {
                    BLL.Instance.DeleteMANL(id);
                    ShowDGV("");
                }    
                else
                {
                    MessageBox.Show("Không xóa được vì đã nhập hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Lehoangngochan_DF f2 = new Lehoangngochan_DF();
            f2.d("");
            f2.ld = ShowDGV;
            f2.Show();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu muốn edit!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (r.Count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Lehoangngochan_DF f2 = new Lehoangngochan_DF();
            string ma = dataGridView1.CurrentRow.Cells["Ma"].Value.ToString();
            f2.d(ma);
            f2.ld = ShowDGV;
            f2.Show();
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            List<string> lma = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lma.Add(dataGridView1.Rows[i].Cells["Ma"].Value.ToString());
            }
            var l = from s in BLL.Instance.SortSV(lma, ((CBBItem)cbbSort.SelectedItem).Text)
                    select new { s.Ma, s.NguyenLieu.TenNguyenLieu, s.SoLuong, s.DonViTinh, s.NguyenLieu.TinhTrang };
            dataGridView1.DataSource = l.ToList();
        }
    }
}
