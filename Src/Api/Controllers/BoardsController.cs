using Api.Controllers.util;
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

    [Authorize(Roles = "admin")]
    [HttpGet("{id:int}")]
    public async Task<BoardOutput?> GetById(int id)
    {
        var result = await _boardService.GetById(id);
        return result;
    }

    [HttpGet("GetByOwnerId")]
    public async Task<ActionResult<IEnumerable<BoardOutput?>>> GetByOwnerId()
    {
        var result = await _boardService.GetByOwnerId(User.GetUserId());
        return Ok(result);
    }

    [Authorize(Roles = "admin")]
    [HttpGet("GetByOwnerId/{id:int}")]
    public async Task<ActionResult<IEnumerable<BoardOutput?>>> GetByOwnerId(int id)
    {
        var result = await _boardService.GetByOwnerId(id);
        return Ok(result);
    }

    [Authorize(Roles = "admin")]
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<BoardOutput?>>> Get()
    {
        var result = await _boardService.Get();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<BoardOutput>> Create(BoardInput boardInput)
    {
        boardInput.OwnerId = User.GetUserId();
        var result = await _boardService.Create(boardInput);
        return Created($"/Boards/{result.Id}", result);
    }
}
