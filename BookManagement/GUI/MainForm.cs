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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetCBBAuthor();
            SetCBBSort();
            SetCBBSearch();
            ShowDGV();
        }

        BookManagement db = new BookManagement();

        private void SetCBBAuthor()
        {
            cbbAuthor.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach(Author a in db.Authors)
            {
                cbbAuthor.Items.Add(new CBBItem { Value = a.AuthorID, Text = a.AuthorName });
            }
            cbbAuthor.SelectedIndex = 0;
        }

        private void SetCBBSort()
        {
            var columnnames = from s in typeof(Book).GetProperties() where s.Name != "Author" select s.Name;
            int index = 0;
            foreach(string i in columnnames)
            {
                cbbSort.Items.Add(new CBBItem { Value = index, Text = i });
                index++;
            }
        }

        private void SetCBBSearch()
        {
            //var columnnames = from s in typeof(Book).GetProperties() where s.Name != "Author" select s.Name;
            var columnnames = from s in typeof(Book).GetProperties() where s.Name != "AuthorID" select s.Name;
            int index = 0;
            foreach (string i in columnnames)
            {
                cbbSearch.Items.Add(new CBBItem { Value = index, Text = i });
                index++;
            }
            cbbSearch.SelectedIndex = 1;
        }

        private void ShowDGV()
        {
            int id = ((CBBItem)cbbAuthor.SelectedItem).Value;
            if (id == 0)
            {
                dataGridView1.DataSource = (from b in BLL.Instance.GetAllBook() 
                                            select new 
                                            {
                                                b.BookID, 
                                                b.BookName, 
                                                b.BookPublishedArea, 
                                                b.BookPublishedTime, 
                                                b.Author.AuthorName
                                            }).ToList();
            }
            else
            {
                dataGridView1.DataSource = (from b in BLL.Instance.GetBookByIDAndName(id, "")
                                            select new
                                            {
                                                b.BookID,
                                                b.BookName,
                                                b.BookPublishedArea,
                                                b.BookPublishedTime,
                                                b.Author.AuthorName
                                            }).ToList();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm df = new DetailForm();
            df.d("");
            df.ld = ShowDGV;
            df.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if(r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sách!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            if(r.Count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 sách!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DetailForm df = new DetailForm();
                df.d(dataGridView1.CurrentRow.Cells["BookID"].Value.ToString());
                df.ld = ShowDGV;
                df.Show();
            }    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sách!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for(int i = 0; i < r.Count; i++)
            {
                string id = dataGridView1.SelectedRows[i].Cells["BookID"].Value.ToString();
                BLL.Instance.DeleteBook(id);
                ShowDGV();
            }    
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    int id = ((CBBItem)cbbAuthor.SelectedItem).Value;
        //    string name = txtSearch.Text;
        //    if (name == "") ShowDGV();
        //    else
        //    {
        //        dataGridView1.DataSource = (from b in BLL.Instance.GetBookByIDAndName(id, name)
        //                                    select new
        //                                    {
        //                                        b.BookID,
        //                                        b.BookName,
        //                                        b.BookPublishedArea,
        //                                        b.BookPublishedTime,
        //                                        b.Author.AuthorName
        //                                    }).ToList();
        //    }     
        //}

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<string> LBookID = new List<string>();
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                LBookID.Add(dataGridView1.Rows[i].Cells["BookID"].Value.ToString());
            }
            string Col = ((CBBItem)cbbSort.SelectedItem).Text;
            dataGridView1.DataSource = (from b in BLL.Instance.SortBook(LBookID, Col)
                                        select new
                                        {
                                            b.BookID,
                                            b.BookName,
                                            b.BookPublishedArea,
                                            b.BookPublishedTime,
                                            b.Author.AuthorName
                                        }).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> LBookID = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                LBookID.Add(dataGridView1.Rows[i].Cells["BookID"].Value.ToString());
            }
            string Col = ((CBBItem)cbbSearch.SelectedItem).Text;
            string input = txtSearch.Text;
            dataGridView1.DataSource = (from b in BLL.Instance.SearchBook(LBookID, Col, input)
                                        select new
                                        {
                                            b.BookID,
                                            b.BookName,
                                            b.BookPublishedArea,
                                            b.BookPublishedTime,
                                            b.Author.AuthorName
                                        }).ToList();
        }

    }
}
