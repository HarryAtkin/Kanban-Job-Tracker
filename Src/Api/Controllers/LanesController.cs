using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class LanesController : ControllerBase
{
    private ILaneService _laneService;
    public LanesController(ILaneService laneService)
    {
        _laneService = laneService;
    }

    [HttpGet("{id:int}")]
    public async Task<LaneOutput?> GetById(int id)
    {
        var result = await _laneService.GetById(id);
        return result;
    }

    [HttpGet("GetByBoardId/{id:int}")]
    public async Task<ActionResult<LaneOutput?>> GetByBoardId(int id)
    {
        var result = await _laneService.GetByBoardId(id);
        return Ok(result);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<LaneOutput?>>> Get()
    {
        var result = await _laneService.Get();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<LaneOutput?>> Create(LaneInput laneInput)
    {
        var result = await _laneService.Create(laneInput);
        return Created($"/Lane/{result.Id}", result);
    }
}
