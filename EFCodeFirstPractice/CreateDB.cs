using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFCodeFirstPractice.DTO;

namespace EFCodeFirstPractice
{
    public class CreateDB: DropCreateDatabaseIfModelChanges<QLSV>
    {
        protected override void Seed(QLSV context)
        {
            context.SVs.AddRange(new SV[]
            {
                new SV {MSSV = "102190101", NameSV = "A", Gender = true, NS = DateTime.Now, ID_Lop = 2},
                new SV {MSSV = "190190102", NameSV = "B", Gender = false, NS = DateTime.Now, ID_Lop = 1},
                new SV {MSSV = "102190103", NameSV = "C", Gender = true, NS = DateTime.Now, ID_Lop = 3},
            });

            context.LSHes.AddRange(new LSH[]
            {
                new LSH {ID_Lop = 1, NameLop = "LSH1"},
                new LSH {ID_Lop = 2, NameLop = "LSH2"},
                new LSH {ID_Lop = 3, NameLop = "LSH3"},
                new LSH {ID_Lop = 4, NameLop = "LSH4"},
            });
        }
    }
}
