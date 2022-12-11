using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring.Assets
{
    public interface IMeteostationFactory
    {
        Meteostation Create();
    }
}

