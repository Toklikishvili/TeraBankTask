using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBankTask.Aplication.DTOs;
using TeraBankTask.Aplication.Features.UserFeature.Command;

namespace TeraBankTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("postUserAsync")]
    public async Task<IActionResult> PostUserAsync([FromBody] CreateUserDTO request)
    {
        var response = await _mediator.Send(new CreateUserCommand(request));

        if (response.Succeeded)
            return Ok(new { Id = response.Data });

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserByIdAsync(int id)
    {
        var response = await _mediator.Send(new DeleteUserByIdCommand(id));
        return response.Succeeded ?Ok(): NotFound();
    }
}
