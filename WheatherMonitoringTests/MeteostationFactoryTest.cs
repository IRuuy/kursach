using FluentAssertions;
using WeatherMonitoring.Assets.Meteostations;
using WeatherMonitoring.Assets.Utils;

namespace WheatherMonitoringTests
{
    [TestClass]
    public class MeteostationFactoryTest : IObserver<Meteostation>
    {

        [TestMethod]
        public void getTest()
        {
            var meteostation = MetereostationFactory.get("Name",
                                                       MeteostationTypes.FOREST_METEOSTATION,
                                                       LocationTypes.NOVOSIBIRSK,
                                                       this,
                                                       5);
            var meteostationAssert = new ForestMeteostation("Name",
                                           MeteostationTypes.FOREST_METEOSTATION,
                                           LocationTypes.NOVOSIBIRSK,
                                           this,
                                           5);
            meteostation.Should().BeEquivalentTo(meteostationAssert);
         
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
