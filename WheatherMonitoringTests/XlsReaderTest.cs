using WeatherMonitoring.Assets.Utils;

namespace WheatherMonitoringTests
{
    [TestClass]
    public class XlsReaderTest
    {
        [TestMethod]
        public void GetDataTest()
        {
            var Data = XlsReader.GetData(new FileInfo("NOVOSIBIRSK.xlsx"), new DateTime(2022, 09, 14));
            Assert.IsNotNull(Data);
        }
    }
}
