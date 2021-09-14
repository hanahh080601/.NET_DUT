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
    public partial class Form2 : Form
    {
        QLSVEntities1 db = new QLSVEntities1();
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
            foreach (LopSH i in db.LopSHes)
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
            s.NameSV = txtName.Text.ToString();
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
                foreach (SV i in db.SVs)
                {
                    if (txtMSSV.Text.ToString() == i.MSSV)
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = false;
                        return;
                    }
                }
                BLL.Instance.addSV(s);
                check = true;
            }
            else
            {
                BLL.Instance.editSV(s);
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
                SV temp = BLL.Instance.getSVByMSSV(ID);
                txtMSSV.Text = temp.MSSV;
                txtMSSV.Enabled = false;
                txtName.Text = temp.NameSV;
                if (temp.Gender == true) rdbMale.Checked = true;
                else rdbFemale.Checked = true;
                dateTimePicker1.Value = Convert.ToDateTime(temp.NS);
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
