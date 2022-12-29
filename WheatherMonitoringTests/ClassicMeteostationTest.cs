using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoring.Assets.Meteostations;
using WeatherMonitoring.Assets.Utils;

namespace WheatherMonitoringTests
{
    [TestClass]
    public class ClassicMeteostationTest: IObserver<Meteostation>
    {
        [TestMethod]
        public void GetDataTests()
        {
            var meteostation = MetereostationFactory.get("Name",
                                                       MeteostationTypes.CLASIC_METEOSTATION,
                                                       LocationTypes.NOVOSIBIRSK,
                                                       this,
                                                       5);
            foreach (var data in meteostation.GetData())
            {
                Assert.IsNotNull(data.Key);
                Assert.IsNotNull(data.Value);
            }
            Assert.AreEqual(meteostation.GetData().Count, 6);
        }


        [TestMethod]
        public void StopTest()
        {
            var meteostation = new ForestMeteostation("Name",
                                                       MeteostationTypes.CLASIC_METEOSTATION,
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
