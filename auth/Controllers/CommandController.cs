using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers;

[ApiController]
[Route("auth")]
public class CommandController : ControllerBase{

    [HttpPost]
    public IActionResult Post() => Ok("POST | New user");

    [HttpPut]
    public IActionResult Put() => Ok("PUT | Edit user");

}