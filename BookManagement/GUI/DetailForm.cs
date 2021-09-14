using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
            SetCBBAuthor();
            d = new MyDel(GetBookID);
            rdbHome.Checked = true;
        }

        BookManagement db = new BookManagement();
        public delegate void MyDel(string s);
        public MyDel d;
        public static string ID;

        public delegate void LoadForm();
        public LoadForm ld;
        public static bool check;
        
        public void GetBookID(string id)
        {
            ID = id;
        }
        private void SetCBBAuthor()
        {
            foreach (Author a in db.Authors)
            {
                cbbAuthor2.Items.Add(new CBBItem { Value = a.AuthorID, Text = a.AuthorName });
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookID = txtBookID.Text;
            b.AuthorID = ((CBBItem)cbbAuthor2.SelectedItem).Value;
            b.BookName = txtName.Text;
            b.BookPublishedTime = Convert.ToDateTime(dateTimePicker1.Value);
            if (rdbHome.Checked == true) b.BookPublishedArea = true;
            else b.BookPublishedArea = false;
            if(ID == "")
            {
                if(txtBookID.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập Mã Sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }    
                foreach(Book book in db.Books)
                {
                    if(txtBookID.Text.ToString() == book.BookID)
                    {
                        MessageBox.Show("Vui lòng nhập Mã Sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        check = false;
                        return;
                    }    
                }
                if(txtName.Text.ToString() == "")
                {
                    MessageBox.Show("Vui lòng nhập Tên Sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                if(dateTimePicker1.Value > DateTime.Now)
                {
                    MessageBox.Show("Vui lòng nhập đúng ngày xuất bản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check = false;
                    return;
                }
                BLL.Instance.AddBook(b);
                check = true;
            }  
            else
            {
                BLL.Instance.UpdateBook(b);
                check = true;
            }
            if(check == true)
            {
                ld();
                this.Dispose();
            }    
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            if(ID != "")
            {
                Book b = db.Books.Find(ID);
                txtBookID.Text = b.BookID;
                txtBookID.Enabled = false;
                txtName.Text = b.BookName;
                for(int i = 0; i < db.Authors.Count(); i++)
                {
                    if (((CBBItem)cbbAuthor2.Items[i]).Value == b.AuthorID)
                        cbbAuthor2.SelectedIndex = i;
                }
                dateTimePicker1.Value = Convert.ToDateTime(b.BookPublishedTime);
                if (b.BookPublishedArea == true)
                {
                    rdbHome.Checked = true;
                }
                else rdbForeign.Checked = true;
            }    
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
