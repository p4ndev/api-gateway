using Forecast.Domains.Entity;

namespace Forecast.Domains.Contract;

public interface IForecastServices {

    WeatherForecast Fill(int index);

}