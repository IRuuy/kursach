using System;
using WeatherMonitoring;
using WeatherMonitoring.Assets.Meteostations;
using WeatherMonitoring.Assets.Utils;

namespace WheatherMonitoringTests
{
    [TestClass]
    public class ForestMeteostationTest: IObserver<Meteostation>
    {
        [TestMethod]
        public void GetDataTests()
        {
            var meteostation = MetereostationFactory.get("Name",
                                                       MeteostationTypes.FOREST_METEOSTATION,
                                                       LocationTypes.NOVOSIBIRSK,
                                                       this,
                                                       5);
            foreach(var data in meteostation.GetData())
            {
                Assert.IsNotNull(data.Key);
                Assert.IsNotNull(data.Value);
            }
            Assert.AreEqual(meteostation.GetData().Count, 8);
        }

        [TestMethod]
        public void CalculateDewPointTest()
        {
            var meteostation = new ForestMeteostation("Name",
                                                       MeteostationTypes.FOREST_METEOSTATION,
                                                       LocationTypes.NOVOSIBIRSK,
                                                       this,
                                                       5);


            Assert.AreEqual(Math.Round(meteostation.calculateDewPoint(20f, 0.70f), 2), 14.36);
        }

        [TestMethod]
        public void StopTest()
        {
            var meteostation = new ForestMeteostation("Name",
                                                       MeteostationTypes.FOREST_METEOSTATION,
                                                       LocationTypes.NOVOSIBIRSK,
                                                       this,
                                                       5);
            meteostation.Stop();

            Assert.AreEqual(meteostation.IsWork, false);
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