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
    public partial class Form2 : Form
    {
        private static int index = 0;
        private static bool status = true;
        public delegate void MyDel(int s);
        public MyDel d;
        public delegate void LoadDataGrid();
        public LoadDataGrid ld;

        public void GetIndexOfEdit(int s)
        {
            index = s;
        }

        public Form2()
        {
            d = new MyDel(GetIndexOfEdit);
            InitializeComponent();
            SetCBBCS();
        }

        public void SetCBBCS()
        {
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

        public void AddGV()
        {
            string id = txtMSGV.Text;
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] < '0' || id[i] > '9')
                {
                    MessageBox.Show("Mã số giảng viên không được chứa kí tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    return;
                }
            }
            foreach (GV s in CSDL_OOP.Instance.DBGV)
            {
                if (s.MSGV == Convert.ToInt32(txtMSGV.Text))
                {
                    MessageBox.Show("Mã giảng viên đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    return;
                }
            }
            if (txtMSGV.Text == "")
            {
                MessageBox.Show("Chưa nhập mã giảng viên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = false;
                return;
            }
            if(txt_SDT.Text.Length != 10)
            {
                MessageBox.Show("Phải nhập số điện thoại có đủ 10 chữ số!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = false;
                return;
            }    
            foreach(char c in txt_SDT.Text.ToString())
            {
                if (c < '0' || c > '9')
                {
                    MessageBox.Show("Chỉ nhập chữ số!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    return;
                }    
                
            }
            if (CSDL_OOP.Instance.CheckSLGV(((CBBItem)cbb_CS.SelectedItem).Value) == false)
            {
                MessageBox.Show("CS được chọn vượt quá số lượng GV giới hạn \n\t Vui lòng chọn lại CS", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = false;
                return;
            }
            GV temp = new GV();
            temp.MSGV = Convert.ToInt32(txtMSGV.Text);
            temp.Name = txtName.Text.ToString();
            temp.SDT = txt_SDT.Text.ToString();
            temp.ID_CS = CSDL_OOP.Instance.getIDCSByName(cbb_CS.SelectedItem.ToString());
            temp.NS = Convert.ToDateTime(dateTimePicker1.Value);
            CSDL_OOP.Instance.AddGVToCSDL(temp);
            status = true;
            return;
        }

        public void EditGV(int msgv)
        {
            if (CSDL_OOP.Instance.CheckSLGV(((CBBItem)cbb_CS.SelectedItem).Value) == false)
            {
                MessageBox.Show("Cơ sở được chọn vượt quá số lượng giảng viên giới hạn \n\t Vui lòng chọn lại cơ sở khác!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = false;
                return;
            }
            int index = CSDL_OOP.Instance.IndexOfGV(msgv);
            GV temp = CSDL_OOP.Instance.DBGV[index];
            txtMSGV.Enabled = false;
            temp.Name = txtName.Text.ToString();
            foreach(char c in txt_SDT.Text.ToString())
            {
                if (c < '0' || c > '9')
                {
                    MessageBox.Show("Vui lòng chỉ nhập chữ số!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    return;
                }
            }
            if (txt_SDT.Text.Length != 10)
            {
                MessageBox.Show("Phải nhập số điện thoại có đủ 10 chữ số!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = false;
                return;
            }
            temp.ID_CS = CSDL_OOP.Instance.getIDCSByName(cbb_CS.SelectedItem.ToString());
            temp.NS = Convert.ToDateTime(dateTimePicker1.Value);
            CSDL_OOP.Instance.DBGV[index] = temp;
            CSDL_OOP.Instance.EditGVToCSDL(CSDL_OOP.Instance.DBGV[index]);
            status = true;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                AddGV();
            }
            else
            {
                EditGV(CSDL_OOP.Instance.DBGV[index].MSGV);
            }
            if (status == true)
            {
                ld();
                Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(index != -1)
            {
                txtMSGV.Enabled = false;
                GV temp = CSDL_OOP.Instance.DBGV[index];
                txtMSGV.Text = temp.MSGV.ToString();
                txtName.Text = temp.Name;
                txt_SDT.Text = temp.SDT;
                for (int i = 0; i < cbb_CS.Items.Count; i++)
                {
                    if (cbb_CS.Items[i].ToString() == temp.ID_CS)
                    {
                        cbb_CS.SelectedIndex = i;
                        break;
                    }
                }
                dateTimePicker1.Value = temp.NS;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
