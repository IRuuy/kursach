using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring.Assets
{
    public class MeteostationAgregator : IObservable<Meteostation>
    {
        private readonly List<IObserver<Meteostation>> _observers;
        public MeteostationAgregator()
        {
            _observers = new List<IObserver<Meteostation>>();
        }
        public IDisposable Subscribe(IObserver<Meteostation> observer)
        {
            _observers.Add(observer);
            return null;
        }

        public void Notify(Meteostation meteostation)
        {
            foreach(var observer in _observers)
                observer.OnNext(meteostation);
        }
    }
}
