﻿using Forecast.Domains.Contract;
using Forecast.Domains.Entity;
using Forecast.ValueObject;

namespace Forecast.Services;

public class ForecastServices : IForecastServices {

    private WeatherForecast? _domain;

    public WeatherForecast Fill(int index) {
        _domain = new();
        FillDate(index);
        FillGuid();
        FillCelsius();
        FillFahrenheit();
        FillSummary();
        return _domain;
    }

    protected void FillGuid()
        => _domain!.Guid = Guid.NewGuid();

    protected void FillDate(int index)
        => _domain!.Date = DateTime.Now.AddDays(index);

    protected void FillCelsius()
        => _domain!.TemperatureC = Random.Shared.Next(-20, 55);

    protected void FillFahrenheit(){
        _domain!.TemperatureF = 32 + (int)(_domain!.TemperatureC / 0.5556);
    }

    protected void FillSummary(){
        _domain!.Summary = Summaries.Data[Random.Shared.Next(Summaries.TOTAL)];
    }

}
