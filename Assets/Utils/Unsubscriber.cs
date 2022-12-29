using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoring.Assets.Utils
{
    public class Unsubscriber<TypeDefenition> : IDisposable
    {
        private readonly List<IObserver<TypeDefenition>> _observers;
        private readonly IObserver<TypeDefenition> _observer;

        public Unsubscriber (List<IObserver<TypeDefenition>> observers, IObserver<TypeDefenition> observer)
        {
            _observers = observers;
            _observer = observer;

        }
        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
