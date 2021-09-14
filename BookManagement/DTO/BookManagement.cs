using System;
using System.Data.Entity;
using System.Linq;

namespace BookManagement
{
    public class BookManagement : DbContext
    {
        // Your context has been configured to use a 'BookManagement' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookManagement.DTO.BookManagement' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookManagement' 
        // connection string in the application configuration file.
        public BookManagement()
            : base("name=BookManagement")
        {
            Database.SetInitializer<BookManagement>(new CreateDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}