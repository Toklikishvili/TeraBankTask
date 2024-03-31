using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeraBankTask.Aplication.DTOs;
using TeraBankTask.Aplication.Features.TransactionFeature.Command;

namespace TeraBankTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("postTransactionAsync")]
    public async Task<IActionResult> PostUserAsync([FromBody] CreateTransactionDTO request)
    {
        var response = await _mediator.Send(new CreateTransactionCommand(request));

        if (response.Succeeded)
            return Ok(new { Id = response.Data });
        if (response.Warninged)
            return NotFound(response.Messages);

        return BadRequest();
    }
}
