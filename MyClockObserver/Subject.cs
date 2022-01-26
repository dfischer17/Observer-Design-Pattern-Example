using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClockObserver
{
    public abstract class Subject
    {
        private List<IObserver> observers = new();

        public void Attach(IObserver observer) => observers.Add(observer);

        public void Detach(IObserver observer) => observers.Remove(observer);

        public void Notifty() => observers.ForEach(observer => observer.Update());
    }
}
