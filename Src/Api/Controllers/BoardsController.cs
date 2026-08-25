using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BoardsController : ControllerBase
{
    private IBoardService _boardService;
    public BoardsController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpGet("{id:int}")]
    public async Task<BoardOutput?> GetById(int id)
    {
        var result = await _boardService.GetById(id);
        return result;
    }

    [HttpGet("GetByOwnerId/{id:int}")]
    public async Task<ActionResult<IEnumerable<BoardOutput?>>> GetByOwnerId(int id)
    {
        var result = await _boardService.GetByOwnerId(id);
        return Ok(result);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<BoardOutput?>>> Get()
    {
        var result = await _boardService.Get();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<BoardOutput>> Create(BoardInput boardInput)
    {
        var result = await _boardService.Create(boardInput);
        return Created($"/Boards/{result.Id}", result);
    }
}
