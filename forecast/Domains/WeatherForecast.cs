namespace Forecast.Domains;

public class WeatherForecast {
    public Guid     Guid            { get; set; }
    public DateTime Date            { get; set; }
    public string?  Summary         { get; set; }
    public int      TemperatureC    { get; set; }
    public int      TemperatureF    { get; set; }
}