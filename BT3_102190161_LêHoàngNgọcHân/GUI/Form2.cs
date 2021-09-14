using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BT3_102190161_LêHoàngNgọcHân.DTO;
using BT3_102190161_LêHoàngNgọcHân.DAL;
using BT3_102190161_LêHoàngNgọcHân.BLL;

namespace BT3_102190161_LêHoàngNgọcHân.GUI
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(string id);
        public MyDel d;
        public delegate void LoadForm();
        public LoadForm ld;

        private static string ID;
        private static bool check = true;

        public void GetMSSV(string id)
        {
            ID = id;
        }

        public Form2()
        {
            d = new MyDel(GetMSSV);
            InitializeComponent();
            SetCBBLopSH();
            rdbMale.Checked = true;
        }

        private void SetCBBLopSH()
        {
            foreach(LopSH i in DAL_QLSV.Instance.getListLSH_DAL())
            {
                cbbLSH2.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
            cbbLSH2.SelectedIndex = 0;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            SV s = new SV();
            s.MSSV = txtMSSV.Text.ToString();
            s.Name = txtName.Text.ToString();
            if (rdbMale.Checked == true) s.Gender = true;
            else s.Gender = false;
            s.NS = Convert.ToDateTime(dateTimePicker1.Value);
            s.ID_Lop = ((CBBItem)cbbLSH2.SelectedItem).Value;
            if (ID == "")
            {
                if (txtMSSV.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập MSSV!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtMSSV.Text.ToString().Length > 10)
                {
                    MessageBox.Show("Vui lòng nhập MSSV có độ dài tối đa là 10 kí tự!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtName.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập tên sinh viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtName.Text.ToString().Length > 40)
                {
                    MessageBox.Show("Vui lòng nhập tên sinh viên tối đa 40 kí tự!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                foreach (SV i in BLL_QLSV.Instance.getListSV_BLL())
                {
                    if (txtMSSV.Text.ToString() == i.MSSV)
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = false;
                        return;
                    }
                }
                BLL_QLSV.Instance.AddSVBLL(s);
                check = true;
            }
            else
            {
                BLL_QLSV.Instance.EditSVBLL(s);
                check = true;
            }
            if (check == true)
            {
                ld();
                this.Dispose();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (ID != "")
            {
                SV temp = BLL_QLSV.Instance.getSVByMSSV(ID);
                txtMSSV.Text = temp.MSSV;
                txtMSSV.Enabled = false;
                txtName.Text = temp.Name;
                if (temp.Gender == true) rdbMale.Checked = true;
                else rdbFemale.Checked = true;
                dateTimePicker1.Value = temp.NS;
                for (int i = 0; i < cbbLSH2.Items.Count; i++)
                {
                    if (((CBBItem)cbbLSH2.Items[i]).Value == temp.ID_Lop)
                    {
                        cbbLSH2.SelectedIndex = i;
                    }
                }
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
