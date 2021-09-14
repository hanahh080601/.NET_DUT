using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst
{
    public class CreateDB: DropCreateDatabaseIfModelChanges<QLSV>
    {
        protected override void Seed(QLSV context)
        {
            context.LSHes.AddRange(new LSH[]
            {
                new LSH {ID_Lop = 1, NameLop = "1911"},
                new LSH {ID_Lop = 2, NameLop = "1912"},
                new LSH {ID_Lop = 3, NameLop = "1913"},
            });

            context.SVs.AddRange(new SV[]
            {
                new SV {MSSV = "101", NameSV = "A", Gender = true, NS = DateTime.Now, ID_Lop = 2},
                new SV {MSSV = "102", NameSV = "B", Gender = false, NS = DateTime.Now, ID_Lop = 1},
                new SV {MSSV = "103", NameSV = "C", Gender = true, NS = DateTime.Now, ID_Lop = 3},
            });
        }
    }
}
