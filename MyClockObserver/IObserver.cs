using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClockObserver
{
    public interface IObserver
    {
        public void Update();
    }
}
