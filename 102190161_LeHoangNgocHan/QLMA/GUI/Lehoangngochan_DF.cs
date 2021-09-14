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
    public partial class Lehoangngochan_DF : Form
    {
        public Lehoangngochan_DF()
        {
            InitializeComponent();
            d = new MyDel(GetMa);
            SetCBBTNL();
            SetCBBMA();
            SetCBBDVT();
            SetCBBTT();          
        }
        QLMA db = new QLMA();

        public delegate void MyDel(string id);
        public MyDel d;

        public delegate void LoadForm(string s);
        public LoadForm ld;

        private static string ID;
        private static bool check;

        public void GetMa(string id)
        {
            ID = id;
        }
        private void SetCBBMA()
        {
            foreach (MonAn i in db.MAs)
            {
                cbbMA2.Items.Add(new CBBItem
                {
                    Value = i.MaMonAn,
                    Text = i.TenMonAn
                });
            }
            cbbMA2.SelectedIndex = 0;
        }

        private void SetCBBTNL()
        {
            List<string> list = BLL.Instance.GetTNL(db.NLs.ToList());
            int j = 0;
            foreach(string i in list)
            {
                cbbTNL.Items.Add(new CBBItem
                {
                    Value = j++,
                    Text = i
                });
            }
            cbbTNL.SelectedIndex = 0;
        }

        private void SetCBBDVT()
        {
            List<String> list = BLL.Instance.GetDVT(db.MA_NLs.ToList());
            int j = 0;
            foreach (string i in list)
            {
                cbbDVT.Items.Add(new CBBItem
                {
                    Value = j++,
                    Text = i
                });
            }
            cbbDVT.SelectedIndex = 0;
        }

        private void SetCBBTT()
        {
            cbbTT.Items.AddRange(new CBBItem[]
            {
                new CBBItem { Value = 0, Text = "Chưa nhập hàng"},
                new CBBItem { Value = 1, Text = "Đã nhập hàng" }
            });
            cbbTT.SelectedIndex = 0;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            MonAn_NguyenLieu manl = new MonAn_NguyenLieu();
            NguyenLieu nl = new NguyenLieu();

            nl.TenNguyenLieu = ((CBBItem)cbbTNL.SelectedItem).Text;
            if (((CBBItem)cbbTT.SelectedItem).Value == 0) nl.TinhTrang = false;
            else nl.TinhTrang = true;

            string ma = txtMa.Text;
            int sl;
            if (int.TryParse(txtSL.Text.ToString(), out sl))
            {
                sl = Convert.ToInt32(txtSL.Text);
            }    
                
            string dvt = ((CBBItem)cbbDVT.SelectedItem).Text;
            int mma = ((CBBItem)cbbMA2.SelectedItem).Value;
            if(ID == "")
            {
                if(((CBBItem)cbbTNL.SelectedItem).Text == "")
                {
                    MessageBox.Show("Vui lòng chọn tên nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtMa.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập mã!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtMa.Text.ToString().Length > 5)
                {
                    MessageBox.Show("Vui lòng nhập mã tối đa 5 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if (txtSL.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                foreach (char c in txtSL.Text.ToString())
                {
                    if (!Char.IsNumber(c))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = false;
                        return;
                    }
                }
                manl = BLL.Instance.ConvertToMANL(ma, sl, dvt, mma, nl);
                BLL.Instance.AddMANL(manl);
                check = true;
            }
            else
            {
                nl.MaNguyenLieu = db.MA_NLs.Find(ID).MaNguyenLieu;
                BLL.Instance.UpdateNL(nl);
                manl = BLL.Instance.ConvertToMANL(ma, sl, dvt, mma, nl);
                BLL.Instance.UpdateMANL(manl);
                check = true;
            }
            if (check == true)
            {
                ld("");
                this.Dispose();
            }
        }

        private void Lehoangngochan_DF_Load(object sender, EventArgs e)
        {
            if(ID != "")
            {
                MonAn_NguyenLieu manl = db.MA_NLs.Find(ID);
                txtMa.Text = manl.Ma;
                txtMa.Enabled = false;

                for(int i = 0; i < cbbTNL.Items.Count; i++)
                {
                    if(manl.NguyenLieu.TenNguyenLieu == ((CBBItem)cbbTNL.Items[i]).Text)
                    {
                        cbbTNL.SelectedIndex = i;
                        break;
                    }    
                }    
                
                txtSL.Text = manl.SoLuong.ToString();
                for (int i = 0; i < cbbDVT.Items.Count; i++)
                {
                    if (manl.DonViTinh == ((CBBItem)cbbDVT.Items[i]).Text)
                    {
                        cbbDVT.SelectedIndex = i;
                        break;
                    }
                }

                bool stt = BLL.Instance.GetNLByID(manl.MaNguyenLieu).TinhTrang;

                if (stt == true) cbbTT.SelectedIndex = 1;
                else cbbTT.SelectedIndex = 0;

                for (int i = 0; i < cbbMA2.Items.Count; i++)
                {
                    if (((CBBItem)cbbMA2.Items[i]).Value == manl.MaMonAn)
                    {
                        cbbMA2.SelectedIndex = i;
                        break;
                    }
                }
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
