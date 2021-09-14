using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public string BookID { get; set; }
        public int AuthorID { get; set; }
        public string BookName { get; set; }
        public DateTime BookPublishedTime { get; set; }
        public bool BookPublishedArea { get; set; }
        [ForeignKey("AuthorID")]

        public virtual Author Author { get; set; }

    }
}
