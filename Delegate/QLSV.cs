using System;
namespace Delegate
{
    class QLSV 
    {
        static private QLSV _Instance;
        public static QLSV Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new QLSV();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public SV[] list {get; set;}
        public int n {get; set;}

        private QLSV()
        {
            list = null;
            n = 0;
        }

        public void Add(SV s)
        {
            if (n == 0)
            {
                list = new SV[n+1];
                list[n] = s;
            }
            else
            {
                SV[] temp = new SV[n];
                for(int i = 0; i<n ; i++)
                {
                    temp[i] = list[i];
                }
                list = new SV[n+1];
                for(int i = 0; i<n ; i++)
                {
                    list[i] = temp[i];
                }
                list[n] = s;
            }
            ++n;
            Console.WriteLine("Thêm thành công!");
        }

        public override string ToString()
        {
            string r = "";
            foreach(SV i in list)
            {
                r += i.ToString() + "\n";
            }
            return r;
        }

        public void Insert(SV s, int index)
        {
            if(index >= n || index < 0) Console.WriteLine("Không tồn tại vị trí cần chèn!");
            else
            {
                SV[] temp = new SV[n+1];
                for(int i = 0; i<index ; i++)
                {
                    temp[i] = list[i];
                }
                temp[index] = s;
                for(int i = index; i<n ; i++)
                {
                    temp[i+1] = list[i];
                }
                list = new SV[n+1];
                for(int i = 0; i<n ; i++)
                {
                    list[i] = temp[i];
                }
            }
        }

        public int IndexOf(SV s)
        {
            int index = -1;
            for(int i = 0; i<n ; i++)
            {
                if (list[i] == s) 
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= n) Console.WriteLine("Không tìm thấy vị trí cần xóa!");
            else if(n == 1) list = null;
            else
            {
                SV[] temp = new SV[n];
                for(int i = 0; i<index ; i++)
                {
                    temp[i] = list[i];
                }
                for(int i = index; i < n-1 ; i++)
                {
                    temp[i] = list[i+1];
                }
                list = new SV[n-1];
                for(int i = 0; i<n-1 ; i++)
                {
                    list[i] = temp[i];
                }
                n--;
                Console.WriteLine("Xoa thanh cong!");
            }
        }

        public void Remove(SV s)
        {
            int k = IndexOf(s);
            if(k==-1) Console.WriteLine("Không tồn tại sinh viên này!");
            else RemoveAt(k);
        }

        public void Edit(int editMSSV)
        {
            int k = -1;
            for(int i = 0; i<n; i++)
            {
                if(list[i]._MSSV == editMSSV)
                {
                    list[i].Update();
                    k = i;
                }
            }
            if(k==-1) Console.WriteLine("Không tồn tại MSSV của SV cần sửa");
            else Console.WriteLine("Update thành công");
        }
        public void Sort()
        {
            for(int i = 0; i< n; i++)
            {
                for(int j = i+1; j<n; j++)
                {
                    if(String.Compare(list[i]._NameSV, list[j]._NameSV) > 0)
                    {
                        SV s = list[i];
                        list[i] = list[j];
                        list[j] = s;
                    }
                }
            }
        }
    }
}