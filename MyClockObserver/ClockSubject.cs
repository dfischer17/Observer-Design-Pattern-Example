using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClockObserver
{
    public class ClockSubject : Subject
    {
        private string? time;

        public string Time
        {
            get => time ?? "** unkown **";
            set
            {
                time = value;
                Notifty();
            }
        }
    }
}
