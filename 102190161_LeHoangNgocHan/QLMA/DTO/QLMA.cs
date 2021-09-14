using System;
using System.Data.Entity;
using System.Linq;

namespace QLMA
{
    public class QLMA : DbContext
    {
        // Your context has been configured to use a 'QLMA' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLMA.DTO.QLMA' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLMA' 
        // connection string in the application configuration file.
        public QLMA()
            : base("name=QLMA")
        {
            Database.SetInitializer<QLMA>(new CreateDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<NguyenLieu> NLs { get; set; }
        public virtual DbSet<MonAn> MAs { get; set; }
        public virtual DbSet<MonAn_NguyenLieu> MA_NLs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}