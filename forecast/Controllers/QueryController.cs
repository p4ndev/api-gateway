using Microsoft.AspNetCore.Mvc;
using Forecast.Services;
using Forecast.Domains;

namespace Forecast.Controllers;

[ApiController]
[Route("[controller]")]
public class QueryController : ControllerBase {

    private readonly IForecastServices _services;

    public QueryController(IForecastServices services) 
        => _services = services;

    [HttpGet]
    public IEnumerable<WeatherForecast> Get() 
        => Enumerable
            .Range(1, 3)
                .Select(i => _services.Fill(i));

}