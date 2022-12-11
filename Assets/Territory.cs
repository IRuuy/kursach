using System;
using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring.Assets
{
    public class Territory
    {
        private MeteostationTypes[] _meteostations;
        private LocationTypes _location;

        public Territory(MeteostationTypes[] meteostations, LocationTypes location)
        {
            _meteostations = meteostations;
            _location = location;
        }
        public void StartMeteostations()
        {
            IMeteostationFactory meteostation = new ForestMeteostation();
        }
    }
}
