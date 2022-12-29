using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Assets.Meteostations;
using WeatherMonitoring.Assets.Utils;
using WeatherMonitoring.Assets;

namespace WheatherMonitoringTests
{
    [TestClass]
    public class AssessmentFireRiskTest : IObserver<Meteostation>
    {
        [TestMethod]
        public void GetTest()
        {
            var meteostation = new ForestMeteostation("Name",
                                           MeteostationTypes.FOREST_METEOSTATION,
                                           LocationTypes.NOVOSIBIRSK,
                                           this,
                                           5);

            Assert.AreEqual(AssessmentFireRisk.Get(2, 20, 14), "1 - ая степень пожароопастности - Отсутсвует.");
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Meteostation value)
        {
            throw new NotImplementedException();
        }
    }
}
