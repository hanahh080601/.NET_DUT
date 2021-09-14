using System;
namespace Delegate 
{
    public class SV 
    {
        public int _MSSV {get; set;}
        public string _NameSV {get; set;}
        public double _DTB {get; set;}

        public virtual void Show()
        {
            Console.WriteLine("MSSV = {0}, NameSV = {1}, DTB = {2}", _MSSV, _NameSV, _DTB);
        }

        public override string ToString()
        {
            return "MSSV = " + _MSSV + ", Name SV = " + _NameSV + ", DTB = " + _DTB;
        }

        public void Update()
        {
            Console.WriteLine("Nhap NameSV moi: ");
            _NameSV = Console.ReadLine();
            Console.WriteLine("Nhap DTB moi: ");
            _DTB = Convert.ToDouble(Console.ReadLine());
        }

        public static bool CompareMSSV(object s1, object s2)
        {
            if(((SV)s1)._MSSV > ((SV)s2)._MSSV) return true;
            else return false;
        }

        public static bool CompareName(object s1, object s2)
        {
            if(String.Compare(((SV)s1)._NameSV,((SV)s2)._NameSV) >= 0) return true;
            else return false;
        }
        
        //user-defined 
        // public SV()
        // {
        //     _MSSV = 0;
        //     _NameSV = "NV0";
        //     _DTB = 0.0;
        // }
        // //hàm dựng chứa tham số
        // public SV(int m, string n, double d)
        // {
        //     _MSSV = m;
        //     _NameSV = n;
        //     _DTB = d;
        // }
        // //copy constructor
        // public SV(SV s)
        // {
        //     _MSSV = s._MSSV;
        //     _NameSV = s._NameSV;
        //     _DTB = s._DTB;
        // }
        //property
        // public string NameSV
        // {
        //     get
        //     {
        //         return _NameSV;
        //     }
        //     set
        //     {
        //         _NameSV = value;
        //     }
        // }
        // public void Thi()
        // {
        //     Console.WriteLine("Thi tu luan");
        // }
    }
}

