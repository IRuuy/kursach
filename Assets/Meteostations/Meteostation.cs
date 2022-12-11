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
        public Meteostation(LocationTypes location)
        {
            _location = location;
            _date = new DateTime(2022, 09, 14);
        }
        public abstract void Start();
        public abstract List<string> GetData();
    }
}
