using Microsoft.AspNetCore.Mvc;
using Auth.Domains.Contract;
using Auth.Domains.Entity;

namespace Auth.Controllers;

[Route("auth")]
[ApiController]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
public class CommandController : ControllerBase{

    private readonly IStorageRepository _repository;

    public CommandController(IStorageRepository repository)
        => _repository = repository;

    [HttpPost]
    public IActionResult Post([FromBody] User model)
        => Created("auth", _repository.Add(model));

}