using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MVC.DTO
{
    class SV
    {
        public string MSSV { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int ID_Lop { get; set; }
        public DateTime NS { get; set; }

        public static bool CompareMSSV(SV s1, SV s2)
        {
            if (string.Compare(s1.MSSV, s2.MSSV) >= 0) return true;
            return false;
        }

        public static bool CompareNameSV(SV s1, SV s2)
        {
            if (string.Compare(s1.Name, s2.Name) >= 0) return true;
            return false;
        }

        public static bool CompareGender(SV s1, SV s2)
        {
            if (string.Compare(s1.Gender.ToString(), s2.Gender.ToString()) >= 0) return true;
            return false;
        }

        public static bool CompareIDLop(SV s1, SV s2)
        {
            if (s1.ID_Lop >= s2.ID_Lop) return true;
            return false;
        }

        public static bool CompareNS(SV s1, SV s2)
        {
            if (string.Compare(s1.NS.ToString(), s2.NS.ToString()) >= 0) return true;
            return false;
        }
    }
}
