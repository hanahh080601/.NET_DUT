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

namespace EFCodeFirstPractice.GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetCBBLSH();
            d = new MyDel(GetMSSV);
            rdbMale.Checked = true;
        }

        QLSV db = new QLSV();

        public void SetCBBLSH()
        {
            foreach(LSH i in db.LSHes)
            {
                cbbLSH2.Items.Add(new CBBItem { Text = i.NameLop, Value = i.ID_Lop });
            }    
        }

        public delegate void MyDel(string id);
        public MyDel d;

        public delegate void LoadForm();
        public LoadForm ld;

        private static string ID;
        private static bool check;

        public void GetMSSV(string id)
        {
            ID = id;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            SV s = new SV();
            s.MSSV = txtMSSV.Text.ToString();
            s.NameSV = txtName.Text.ToString();
            s.NS = Convert.ToDateTime(dateTimePicker1.Value);
            if (rdbMale.Checked == true) s.Gender = true;
            else s.Gender = false;
            s.ID_Lop = ((CBBItem)cbbLSH2.SelectedItem).Value;
            if(ID == "")
            {
                if(txtMSSV.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập MSSV!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }   
                if(txtMSSV.Text.ToString().Length > 10)
                {
                    MessageBox.Show("MSSV dài không quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }  
                if(txtName.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtName.Text.ToString().Length > 40)
                {
                    MessageBox.Show("Họ tên dài không quá 40 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                foreach (SV i in db.SVs)
                {
                    if(txtMSSV.Text.ToString() == i.MSSV)
                    {
                        MessageBox.Show("MSSV đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = false;
                        return;
                    }    
                }
                BLL.Instance.AddSV(s);
                check = true;
            } 
            else
            {
                BLL.Instance.UpdateSV(s);
                check = true;
            } 
            if(check == true)
            {
                ld();
                this.Dispose();
            }    
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(ID != "")
            {
                SV s = db.SVs.Find(ID);
                txtMSSV.Text = s.MSSV;
                txtMSSV.Enabled = false;
                txtName.Text = s.NameSV;
                dateTimePicker1.Value = Convert.ToDateTime(s.NS);
                if (s.Gender == true)
                {
                    rdbMale.Checked = true;
                }
                else rdbFemale.Checked = true;
                for(int i = 0; i < cbbLSH2.Items.Count; i++)
                {
                    if(((CBBItem)cbbLSH2.Items[i]).Value == s.ID_Lop)
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
