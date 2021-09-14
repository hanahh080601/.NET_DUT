using System;

namespace Delegate
{
    public class TimeEventArgs : EventArgs
    {
        public DateTime timer{get; set;}

        public TimeEventArgs(DateTime t)
        {
            timer = t;
        }
    }
}