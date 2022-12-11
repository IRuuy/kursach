using System;
using WeatherMonitoring.Assets.Meteostations;
using WeatherMonitoring.Assets;

public class ForestMeteostationFactory : IMeteostationFactory
{
    public Meteostation Create(LocationTypes locationTypes)
    {
        return new ForestMeteostation(locationTypes);
    }
}

