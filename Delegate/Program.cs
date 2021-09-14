using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Delegate
{
    class Program
    {
        public delegate void MyDel(int x, int y);
        public static void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        public static void Sub(int x, int y)
        {
            Console.WriteLine(x - y);
        }
        public static void Calculate(int x, int y, MyDel d)
        {
            d(x,y);
        }

        public delegate bool Compare(object o1, object o2);

        public static void Sort(object[] arr, Compare cmp)
        {
            for(int i = 0; i < arr.Length-1; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if(cmp(arr[i],arr[j]))
                    {
                        object temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // MyDel d = new MyDel(Add);
            // int z = d(3,4);        // xem d là 1 đối tượng cụ thể
            // Console.WriteLine(z);
            // int t = d.Invoke(3,4); // xem d là 1 đối tượng, pthuc invoke xem d đang tham chiếu đến hàm nào và sẽ thực hiện hàm đó
            // Console.WriteLine(t);
            // int w = Calculate(4,3,Add);
            // Console.WriteLine(w);
            // MyDel d = new MyDel(Add);
            // d += new MyDel(Sub);
            // d += new MyDel(Sub); 
            // // Sau 3 lệnh này, tham chiếu tới 2 hàm nhưng thực hiện hàm sub 2 lần.
            // d-= new MyDel(Sub);
            // d(2,1);


            // SV[] arr = new SV[]
            // {
            //     new SV {_MSSV = 101, _NameSV = "D", _DTB = 1.1},
            //     new SV {_MSSV = 102, _NameSV = "B", _DTB = 2.2},
            //     new SV {_MSSV = 103, _NameSV = "C", _DTB = 3.3},
            // };
            // Sort(arr,SV.CompareName);
            // foreach(SV i in arr)
            // {
            //     Console.WriteLine(i.ToString());
            // }


            // Clock c = new Clock();
            // AnalogClock ac = new AnalogClock();
            // DigitalClock dc = new DigitalClock();
            // // ac.DK(c);
            // // dc.DK(c);
            // c.OnSecondChange += new Clock.SecondHandler(ac.ShowAC);
            // c.OnSecondChange += new Clock.SecondHandler(dc.ShowDC);
            // c.Run();


            List<SV> l = new List<SV>();
            List<int> l1 = new List<int>();
            SV s1 = new SV {_MSSV = 101, _NameSV = "D", _DTB = 1.1};
            SV s2 = new SV {_MSSV = 102, _NameSV = "B", _DTB = 2.2};
            SV s3 = new SV {_MSSV = 103, _NameSV = "C", _DTB = 3.3};
            l.Add(s1);
            l.AddRange(new SV[] {s3,s2});
            int index = l.IndexOf(s4);
            l.RemoveAt(0);
            l.ToArray();
            arr.ToList();
            
            foreach(SV i in l)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
        
    
        // 1 delegate nếu tham chiếu tới nhiều hàm thì thường kiểu trả về là void.
