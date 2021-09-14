using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new HashSet<Book>();
        }
    }
}
