using System;
using WeatherMonitoring.Assets.Meteostations;
using WeatherMonitoring.Assets;

public class ForestMeteostationFactory : IMeteostationFactory
{
    LocationTypes _locationType;
    IObserver<Meteostation> _observer;
    int _periodSendingData;
    public ForestMeteostationFactory(LocationTypes locationType,
                                    IObserver<Meteostation> observer, int periodSendingData)
    {
        _locationType = locationType;
        _observer = observer;
        _periodSendingData = periodSendingData;
    }
    public Meteostation Create() => new ForestMeteostation(_locationType, _observer, _periodSendingData);
}

