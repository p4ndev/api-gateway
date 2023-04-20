using Microsoft.AspNetCore.Mvc;
using Auth.Domains.Contract;
using Auth.Domains.Entity;
using Infrastructure;

namespace Auth.Controllers;

[Route("auth")]
[ApiController]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
public class QueryController : ControllerBase{

    private readonly IStorageRepository _repository;

    public QueryController(IStorageRepository repository)
        => _repository = repository;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromBody] User model) {
        bool found = _repository.Find(model);
        return found ? Ok() : NotFound();
    }

    [HttpGet("encrypt")]
    public IActionResult Encrypt([FromServices] ICryptoProvider crypto) {
        return Ok(crypto.Encrypt("Gustavo Henrique"));
    }

    [HttpGet("decrypt")]
    public IActionResult Decrypt([FromServices] ICryptoProvider crypto){
        return Ok(crypto.Decrypt("UlroMB5zxsYXe7APx7/uNcPUy+W8XL3uTJPQRI1Ai3yl4Kk5AO3AkI13KQSdZ35L"));
    }

}