using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate
{
    public class AnalogClock
    {
        public void DK(Clock c)//hàm dk cho đối tượng phát sinh sự kiện tham chiếu tới lớp analog
        {
            c.OnSecondChange += new Clock.SecondHandler(ShowAC);
        }

        public void ShowAC(object o, TimeEventArgs e)
        {
            Console.WriteLine("AC: {0}:{1}:{2}:{3}",e.timer.Hour, e.timer.Minute, e.timer.Second, e.timer.Millisecond);
        }
    }
}