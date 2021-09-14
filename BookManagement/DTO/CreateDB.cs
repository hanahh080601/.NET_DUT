using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookManagement
{
    public class CreateDB
        : DropCreateDatabaseIfModelChanges<BookManagement>
    {
        protected override void Seed(BookManagement context)
        {
            context.Authors.AddRange(new Author[]
            {
                new Author { AuthorID = 1, AuthorName = "Le Hoang"},
                new Author { AuthorID = 2, AuthorName = "Ngoc Han"},
                new Author { AuthorID = 3, AuthorName = "Han Le"},
                new Author { AuthorID = 4, AuthorName = "Hoang Ngoc"},
            });

            context.Books.AddRange(new Book[]
            {
                new Book { BookID = "B1", AuthorID = 1, BookName = "Khoa hoc", BookPublishedTime = DateTime.Now, BookPublishedArea = true },
                new Book { BookID = "B2", AuthorID = 2, BookName = "Lich su", BookPublishedTime = DateTime.Now, BookPublishedArea = false },
                new Book { BookID = "B3", AuthorID = 3, BookName = "Dia li", BookPublishedTime = DateTime.Now, BookPublishedArea = false },
                new Book { BookID = "B4", AuthorID = 4, BookName = "Toan", BookPublishedTime = DateTime.Now, BookPublishedArea = true },
            });

        }
    }
}
