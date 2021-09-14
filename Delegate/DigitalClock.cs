using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate
{
    public class DigitalClock
    {
        public void DK(Clock c)//hàm dk cho đối tượng phát sinh sự kiện tham chiếu tới lớp digital
        {
            c.OnSecondChange += new Clock.SecondHandler(ShowDC);
        }

        public void ShowDC(object o, TimeEventArgs e)
        {
            Console.WriteLine("DC: {0}:{1}:{2}:{3}",e.timer.Hour, e.timer.Minute, e.timer.Second, e.timer.Millisecond);
        }
    }
}