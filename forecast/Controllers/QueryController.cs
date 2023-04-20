using Microsoft.AspNetCore.Authorization;
using Forecast.Domains.Contract;
using Microsoft.AspNetCore.Mvc;
using Forecast.Domains.Entity;

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

    [HttpGet("identity")]
    public IActionResult Test() {

        var usr = HttpContext.User;

        return Ok();

    }

}