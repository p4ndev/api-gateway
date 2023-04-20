using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers;

[ApiController]
[Route("auth")]
public class QueryController : ControllerBase{

    [HttpGet]
    public IActionResult Get() => Ok("GET | Sign in");

}