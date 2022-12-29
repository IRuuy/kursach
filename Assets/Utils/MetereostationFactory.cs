using System;
using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring.Assets.Utils
{
    public static class MetereostationFactory
    {
        public static Meteostation get(string name,
                                        MeteostationTypes meteostationType,
                                        LocationTypes locationType,
                                        IObserver<Meteostation> observer,
                                        int periodSendingData)
        {
            return meteostationType switch
            {
                MeteostationTypes.FOREST_METEOSTATION => new ForestMeteostation(name,
                                                                                meteostationType,
                                                                                locationType,
                                                                                observer,
                                                                                periodSendingData),

                MeteostationTypes.CLASIC_METEOSTATION => new ClasicMeteriostation(name,
                                                                                  meteostationType,
                                                                                  locationType,
                                                                                  observer,
                                                                                  periodSendingData),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
