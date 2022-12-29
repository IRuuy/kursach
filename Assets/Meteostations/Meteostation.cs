using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Assets.Utils;

namespace WeatherMonitoring.Assets.Meteostations
{
    public abstract class Meteostation
    {
        protected string _name;
        protected LocationTypes _location;
        protected MeteostationTypes _meteostationType;
        protected DateTime _date;
        protected MeteostationAgregator _meteostationAgregator;
        protected int _periodSendingData;
        protected IDisposable _observerToken;

        public Meteostation(string name, MeteostationTypes meteostationType, LocationTypes location, IObserver<Meteostation> observer, int periodSendingData)
        {
            _name = name;
            _meteostationType = meteostationType;
            _location = location;
            _date = new DateTime(2022, 09, 14);
            _periodSendingData = periodSendingData;
            _meteostationAgregator = new MeteostationAgregator();
            _observerToken = _meteostationAgregator.Subscribe(observer);
        }

        public abstract void Start();
        public abstract void Stop();
        public void Dispose()
        {
            _observerToken.Dispose();
        }
        public abstract Dictionary<string, string> GetData();
        public string Name => _name;
        public MeteostationTypes MeteostationType => _meteostationType;
    }
}
