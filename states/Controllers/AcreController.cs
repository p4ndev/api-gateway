using Microsoft.AspNetCore.Mvc;
using States.Domains;

namespace States.Controllers;

[ApiController]
[Route("[controller]")]
public class AcreController : ControllerBase {

    private readonly IAcreServices _services;

    public AcreController(IAcreServices services) => _services = services;

    [HttpGet]
    public async Task<ActionResult<long>> GetFullNameAsync() {

        if(!_services.HasLoaded())
            await _services.LoadAsync();

        if (!_services.TryParse())
            return StatusCode(500);

        return Ok(_services.GetCount());

    }

    [HttpGet("{letter:length(1)}")]
    public async Task<ActionResult<IEnumerable<string>>> GetCitiesAsync(
        [FromRoute] string letter
    ){

        if (!_services.HasLoaded())
            await _services.LoadAsync();

        if (!_services.TryParse())
            return StatusCode(500);

        if (String.IsNullOrEmpty(letter))
            return BadRequest();

        var results = _services.GetCities(letter.ToUpper()[0]);

        return StatusCode((results is null ? 404 : 200), results);

    }

}