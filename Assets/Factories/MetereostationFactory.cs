using System;
using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring.Assets.Factories
{
    public static class MetereostationFactory
    {
        public static Meteostation get(MeteostationTypes meteostationType,
                                        LocationTypes locationType,
                                        IObserver<Meteostation> observer,
                                        int periodSendingData)
        {
            return meteostationType switch
            {
                MeteostationTypes.FOREST_METEOSTATION => new ForestMeteostation(locationType,
                                                                                observer,
                                                                                periodSendingData),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
