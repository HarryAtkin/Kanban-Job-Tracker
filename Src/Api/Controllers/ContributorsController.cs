using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ContributorsController : ControllerBase
{
    private IContributorService _contributorService;
    public ContributorsController(IContributorService contributorService)
    {
        _contributorService = contributorService;
    }

    [HttpGet("{id:int}")]
    public async Task<ContributorOutput?> GetById(int id)
    {
        var result = await _contributorService.GetById(id);
        return result;
    }

    [HttpGet("GetByAccountId/{id:int}")]
    public async Task<ActionResult<ContributorOutput?>> GetByAccountId(int id)
    {
        var result = await _contributorService.GetByAccountId(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("GetByBoardId/{id:int}")]
    public async Task<ActionResult<IEnumerable<ContributorOutput?>>> GetByBoardId(int id)
    {
        var result = await _contributorService.GetByBoardId(id);
        return Ok(result);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ContributorOutput?>>> Get()
    {
        var result = await _contributorService.Get();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ContributorOutput>> Create(ContributorInput contributorInput)
    {
        var result = await _contributorService.Create(contributorInput);
        return Created("Contributors/Create", result);
    }
}
