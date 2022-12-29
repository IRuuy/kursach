using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using WeatherMonitoring.Assets.Utils;

namespace WeatherMonitoring.Assets.Meteostations
{
    internal class ClasicMeteriostation : Meteostation
    {
        private float _airMoisture;
        private float _airTemperature;
        private float _precipitationPerDay;
        private bool _isWork;

        public bool IsWork { get => _isWork; set => _isWork = value; }

        public ClasicMeteriostation(string name, MeteostationTypes meteostationType, LocationTypes location, IObserver<Meteostation> observer, int periodSendingData)
            : base(name, meteostationType, location, observer, periodSendingData) { }

        public override void Start()
        {
            IsWork = true;

            new Thread(() =>
            {
                for (int i = 0; IsWork == true; i++)
                {
                    var date = new DateTime(_date.Year, _date.Month, _date.Day);
                    var file = new FileInfo($"{_location.ToString()}.xlsx");
                    var Data = XlsReader.GetData(file, date);

                    _airMoisture = float.Parse(Data["AIR_MOISTURE"], CultureInfo.InvariantCulture.NumberFormat) / 100;
                    _airTemperature = float.Parse(Data["MAX_TEMPERATURE"], CultureInfo.InvariantCulture.NumberFormat);
                    _precipitationPerDay = float.Parse(Data["PRECIPITATION"], CultureInfo.InvariantCulture.NumberFormat);
                    _date = _date.AddDays(_periodSendingData);

                    Thread.Sleep(_periodSendingData*3000);
                    if (IsWork == true)
                        _meteostationAgregator.Notify(this);
                }
            }).Start();
        }

        public override void Stop() { IsWork = false; }

        public override Dictionary<string, string> GetData() => new Dictionary<string, string>
        {
                { "Имя метеостанции: " , _name.ToString() },
                { "Локация: " , _location.ToString() },
                { "Дата: " , _date.ToString() },
                { "Температура воздуха" , _airTemperature.ToString() },
                { "Влажность воздуха:" , _airMoisture.ToString()},
                { "Количество осадков:" , _precipitationPerDay.ToString() },
        };
    }
}
