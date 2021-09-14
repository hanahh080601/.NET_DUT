using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class BLL
    {
        BookManagement db = new BookManagement();
        public static BLL Instance
        {
            get 
            {
                if(_Instance == null)
                {
                    _Instance = new BLL();
                }
                return _Instance;
            }
            private set { }
        }

        private static BLL _Instance;

        public List<Book> GetAllBook()
        {
            return db.Books.ToList();
        }

        public Book GetBookByBookID(string id)
        {
            if (db.Books.Find(id).BookID == null)
            {
                throw new Exception("BookID does not exist!");
            }
            else return db.Books.Find(id);
        }

        public List<Book> GetListBookDGV(List<string> LBookID)
        {
            List<Book> list = new List<Book>();
            foreach(string id in LBookID)
            {
                list.Add(GetBookByBookID(id));
            }
            return list;
        }

        public List<Book> GetBookByIDAndName(int id, string name)
        {
            List<Book> list = new List<Book>();
            if(id == 0 && name != "")
            {
                list = (from b in db.Books where b.BookName.Contains(name) select b).ToList();
            }
            else if(id != 0)
            {
                list = (from b in db.Books where b.AuthorID == id && b.BookName.Contains(name) select b).ToList();
            }
            else
            {
                list = (from b in db.Books where b.AuthorID == id select b).ToList();
            }
            return list;
        }

        public void AddBook(Book b)
        {
            db.Books.Add(b);
            db.SaveChanges();
        }

        public void UpdateBook(Book b)
        {
            Book book = db.Books.Find(b.BookID);
            book.BookName = b.BookName;
            book.AuthorID = b.AuthorID;
            book.BookPublishedArea = b.BookPublishedArea;
            book.BookPublishedTime = b.BookPublishedTime;
            db.SaveChanges();
        }

        public void DeleteBook(string id)
        {
            Book b = db.Books.Find(id);
            db.Books.Remove(b);
            db.SaveChanges();
        }

        public List<Book> SearchBook(List<string> LBookID, string Col, string input)
        {
            List<Book> list = new List<Book>();
            switch(Col)
            {
                case "BookID":
                    list = (from b in GetListBookDGV(LBookID) where b.BookID.ToLower().Contains(input.ToLower()) select b).ToList();
                    break;     
                case "BookName":
                    list = (from b in GetListBookDGV(LBookID) where b.BookName.ToLower().Contains(input.ToLower()) select b).ToList();
                    break;
                case "BookPublishedTime":
                    list = (from b in GetListBookDGV(LBookID) where b.BookPublishedTime.ToString().Contains(input) select b).ToList();
                    break;
                case "BookPublishedArea":
                    if ("vietnam".Contains(input.ToLower().Replace(" ", "")))
                    {
                        list = (from b in GetListBookDGV(LBookID) where b.BookPublishedArea == true select b).ToList();
                    }    
                    else
                    {
                        list = (from b in GetListBookDGV(LBookID) where b.BookPublishedArea == false select b).ToList();
                    }    
                    break;
                case "Author":
                    list = (from b in GetListBookDGV(LBookID) where b.Author.AuthorName.ToLower().Contains(input.ToLower()) select b).ToList();
                    break;
            }    
            return list;
        }

        public List<Book> SortBook(List<string> LBookID, string Col)
        {
            List<Book> list = new List<Book>();
            switch(Col)
            {
                case "BookID":
                    list = (from b in GetListBookDGV(LBookID) orderby b.BookID select b).ToList();
                    break;
                case "AuthorID":
                    list = (from b in GetListBookDGV(LBookID) orderby b.AuthorID select b).ToList();
                    break;
                case "BookName":
                    list = (from b in GetListBookDGV(LBookID) orderby b.BookName select b).ToList();
                    break;
                case "BookPublishedTime":
                    list = (from b in GetListBookDGV(LBookID) orderby b.BookPublishedTime select b).ToList();
                    break;
                case "BookPublishedArea":
                    list = (from b in GetListBookDGV(LBookID) orderby b.BookPublishedArea select b).ToList();
                    break;
            }    
            return list;
        }
    }
}
