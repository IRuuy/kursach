﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DocumentFormat.OpenXml.Math;

namespace WeatherMonitoring.Assets.Meteostations
{
    public class ForestMeteostation : Meteostation
    {
        float _dewPoint;
        float _airMoisture;
        float _airTemperature;
        float _precipitationPerDay;
        public ForestMeteostation(LocationTypes location) : base(location){}
        
        ///<summary>
        /// <see href="https://ru.wikipedia.org/wiki/Точка_росы">Литература про точку росы</see>
        /// </summary>
        /// <returns>float значение точки росы</returns>
        private float calculateDewPoint()
        {
            const float a = 17.27f;
            const float b = 237.7f;
            float temp = ((a * _airTemperature) / (b + _airTemperature)) + (float)Math.Log(_airMoisture);
            return (b * temp) / (a - temp);
        }

        ///<summary>
        /// <para>Возвращает строку - "степень пожароопастности"</para>
        /// <see href="http://downloads.igce.ru/publications/metodi_ocenki/07.pdf">Литература про лесные пожары</see>
        /// </summary>
        private string GetAssessmentFireRisk()
        {
            DateTime prevDay;
            Dictionary<string, string> Data;
            int dayCount = 0;
            float CIFD = 0; // Сomplex Indicator of Fire Danger(Комплексный Показатель Пожарной Опастности)
            
            do
            {
                dayCount++;
                prevDay = _date.AddDays((dayCount * -1));
                Data = XlsReader.GetData(new FileInfo($"{_location.ToString()}.xlsx"), prevDay);
            } while (float.Parse(Data["PRECIPITATION"]) < 3);
            dayCount--;
            
            // По формуле В.Г.Нестерова
            for (int i = 0; i < dayCount; i++)
                CIFD += _airTemperature * (_airTemperature - _dewPoint);

            if (CIFD < 300)
                return "1 - ая степень пожароопастности. Отсутсвует.";
            else if (301 < CIFD && CIFD < 1000)
                return "2 - ая степень пожароопастности. Малая.";
            else if (1001 < CIFD && CIFD < 4000)
                return "3 - ая степень пожароопастности. Средняя.";
            else if (4001 < CIFD && CIFD < 10000)
                return "4 - ая степень пожароопастности. Высокая.";
            else
                return "5 - ая степень пожароопастности. Чрезвычайная.";
        }
        public override void Start()
        {
            var Data = XlsReader.GetData(new FileInfo($"{_location.ToString()}.xlsx"), _date);
       
            _airMoisture = float.Parse(Data["AIR_MOISTURE"]) / 100;
            _airTemperature = float.Parse(Data["MAX_TEMPERATURE"], CultureInfo.InvariantCulture.NumberFormat);
            _precipitationPerDay = float.Parse(Data["PRECIPITATION"], CultureInfo.InvariantCulture.NumberFormat);
            _dewPoint = calculateDewPoint();

            MessageBox.Show(string.Join("\n", GetData()));
        }

        public override List<string> GetData() => new List<string>
        {
                "Температура воздуха: " + _airTemperature,
                "Влажность воздуха: " + _airMoisture,
                "Колличество осадков: " + _precipitationPerDay,
                "Точка росы: " + _dewPoint,
                GetAssessmentFireRisk(),
        };
    }
}
