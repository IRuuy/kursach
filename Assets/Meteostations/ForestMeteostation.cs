using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using WeatherMonitoring.Assets.Utils;

namespace WeatherMonitoring.Assets.Meteostations
{
    public class ForestMeteostation : Meteostation
    {
        private float _dewPoint;
        private float _airMoisture;
        private float _airTemperature;
        private float _precipitationPerDay;
        private bool _isWork;

        public bool IsWork { get => _isWork; set => _isWork = value; }

        public ForestMeteostation(string name, MeteostationTypes meteostationType, LocationTypes location, IObserver<Meteostation> observer, int periodSendingData)
            : base(name, meteostationType, location, observer, periodSendingData) { }

        ///<summary>
        /// <see href="https://ru.wikipedia.org/wiki/Точка_росы">Литература про точку росы(Клик)</see>
        /// </summary>
        /// <returns>float значение точки росы</returns>
        public float calculateDewPoint(float airTemperature, float airMoisture)
        {
            const float a = 17.27f;
            const float b = 237.7f;
            float temp = ((a * airTemperature) / (b + airTemperature)) + (float)Math.Log(airMoisture);
            return (b * temp) / (a - temp);
        }

        ///<summary>
        /// <para>Возвращает строку - "степень пожароопастности"</para>
        /// <see href="http://downloads.igce.ru/publications/metodi_ocenki/07.pdf">Литература про лесные пожары(Клик)</see>
        /// </summary>
        private int calculateCountDayWithoutPrecipation()
        {
            DateTime prevDay;
            Dictionary<string, string> Data;
            int countDayWithoutPrecipitation = 0;

            do
            {
                countDayWithoutPrecipitation++;

                prevDay = _date.AddDays((countDayWithoutPrecipitation * -1));
                prevDay = new DateTime(prevDay.Year, prevDay.Month, prevDay.Day);
                Data = XlsReader.GetData(new FileInfo($"{_location.ToString()}.xlsx"), prevDay);
            } while (float.Parse(Data["PRECIPITATION"]) < 2);
            countDayWithoutPrecipitation--;
            return countDayWithoutPrecipitation;
        }
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
                    _dewPoint = calculateDewPoint(_airTemperature, _airMoisture);
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
                { "Количество осадков: " , _precipitationPerDay.ToString() },
                { "Точка росы" , _dewPoint.ToString() },
                { "Риск пожара:" ,  AssessmentFireRisk.Get(calculateCountDayWithoutPrecipation(), (int)_airTemperature, (int)_dewPoint) },
        };
    }
}
