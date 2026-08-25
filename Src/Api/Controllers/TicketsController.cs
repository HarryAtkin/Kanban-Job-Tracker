using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TicketsController : ControllerBase
{
    private ITicketService _ticketService;
    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("{id:int}")]
    public async Task<TicketOutput?> GetById(int id)
    {
        var result = await _ticketService.GetById(id);
        return result;
    }

    [HttpGet("GetFilter")]
    public async Task<ActionResult<IEnumerable<TicketOutput?>>> GetByFilter([FromQuery] TicketFilterInput input)
    {
        var result = await _ticketService.GetByFilter(input);
        return Ok(result);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<TicketOutput?>>> Get()
    {
        var result = await _ticketService.Get();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<TicketOutput>> Create(TicketInput accountInput)
    {
        var result = await _ticketService.Create(accountInput);
        return Created($"/Ticket/{result.Id}", result);
    }
}
