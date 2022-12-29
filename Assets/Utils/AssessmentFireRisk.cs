using System.Collections.Generic;
using System.Linq;

namespace WeatherMonitoring.Assets.Utils
{
    public static class AssessmentFireRisk
    {
        private static Dictionary<int, string> _CIFD = new Dictionary<int, string>(){
            {300, "1 - ая степень пожароопастности - Отсутсвует."},
            {1000, "2 - ая степень пожароопастности - Малая."},
            {4000,  "3 - ая степень пожароопастности - Средняя."},
            {10000, "4 - ая степень пожароопастности - Высокая."},
        };
        ///<summary>
        /// <para>Возвращает строку - "степень пожароопастности"</para>
        /// <see href="http://downloads.igce.ru/publications/metodi_ocenki/07.pdf">Литература про лесные пожары(Клик)</see>
        /// </summary>
        public static string Get(int countDayWithoutPrecipitation, int airTemperature, int dewPoint)
        {
            int CIFD = 0;
            // По формуле В.Г.Нестерова
            for (int i = 0; i < countDayWithoutPrecipitation; i++)
                CIFD += airTemperature * (airTemperature - dewPoint);

            string resultString = _CIFD.ElementAt(0).Value;
            
            for (int i = 1; i < _CIFD.Count; i++)
                if (_CIFD.ElementAt(i-1).Key < CIFD && CIFD <= _CIFD.ElementAt(i).Key)
                    resultString = _CIFD.ElementAt(i).Value;

            return resultString;
        }
    }
}
