using Forecast.Domains;

namespace Forecast.Services;

public interface IForecastServices{

    WeatherForecast Fill(int index);

}