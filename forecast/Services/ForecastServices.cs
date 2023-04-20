using Forecast.ValueObjects;
using Forecast.Domains;

namespace Forecast.Services;

public sealed class ForecastServices : IForecastServices {

    private WeatherForecast? _domain;

    public WeatherForecast Fill(int index) {
        _domain = new();
        {
            FillDate(index);
            FillGuid();
            FillCelsius();
            FillFahrenheit();
            FillSummary();
        }
        return _domain;
    }

    private void FillGuid()
        => _domain!.Guid = Guid.NewGuid();

    private void FillDate(int index)
        => _domain!.Date = DateTime.Now.AddDays(index);

    private void FillCelsius()
        => _domain!.TemperatureC = Random.Shared.Next(-20, 55);

    private void FillFahrenheit(){
        _domain!.TemperatureF = 32 + (int)(_domain!.TemperatureC / 0.5556);
    }

    private void FillSummary(){
        _domain!.Summary = Summaries.Data[Random.Shared.Next(Summaries.TOTAL)];
    }

}
