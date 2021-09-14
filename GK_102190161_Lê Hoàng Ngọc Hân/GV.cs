using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190161_Lê_Hoàng_Ngọc_Hân
{
    class GV
    {
        public int MSGV { get; set; }
        public string Name { get; set; }
        public string SDT { get; set; }
        public string ID_CS { get; set; }
        public DateTime NS { get; set; }


        public static bool CompareIDGV(GV s1, GV s2)
        {
            if (s1.MSGV >= s2.MSGV) return true;
            else return false;
        }

        public static bool CompareTen(GV s1, GV s2)
        {
            if (string.Compare(s1.Name, s2.Name) > 0) return true;
            else return false;
        }

        public static bool CompareSDT(GV s1, GV s2)
        {
            if (string.Compare(s1.SDT, s2.SDT) > 0) return true;
            else return false;
        }

        public static bool CompareNS(GV s1, GV s2)
        {
            if (string.Compare(s1.NS.ToString(), s2.NS.ToString()) > 0) return true;
            else return false;
        }

        public static bool CompareIDCS(GV s1, GV s2)
        {
            if (string.Compare(s1.ID_CS, s2.ID_CS) > 0) return true;
            else return false;
        }
    }
}
