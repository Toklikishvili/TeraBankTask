using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeraBankTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Post()
    {
        return Ok(ModelState);
    }
}
