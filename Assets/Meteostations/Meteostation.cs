using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoring.Assets.Meteostations
{
    public abstract class Meteostation
    {
        protected LocationTypes _location;
        protected DateTime _date;
        protected MeteostationAgregator _meteostationAgregator;
        protected int _periodSendingData;
        public Meteostation(LocationTypes location, IObserver<Meteostation> observer, int periodSendingData)
        {
            _location = location;
            _date = new DateTime(2022, 09, 14);
            _periodSendingData = periodSendingData;
            _meteostationAgregator = new MeteostationAgregator();
            _meteostationAgregator.Subscribe(observer);
        }
        public abstract void Start();
        public abstract List<string> GetData();
    }
}
