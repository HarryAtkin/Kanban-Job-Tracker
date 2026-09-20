using Api.Controllers.util;
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

    [Authorize(Roles = "admin")]
    [HttpGet()]
    public async Task<ContributorOutput?> GetById(int id)
    {
        var result = await _contributorService.GetById(id);
        return result;
    }

    [Authorize(Roles = "admin")]
    [HttpGet("GetByAccountId")]
    public async Task<ActionResult<ContributorOutput?>> GetByAccountId(int id)
    {
        var result = await _contributorService.GetByAccountId(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("GetByBoardId/{id:int}")]
    public async Task<ActionResult<IEnumerable<ContributorOutput?>>> GetByBoardId(int id)
    {
        var result = await _contributorService.GetByBoardId(id, User.GetUserId());
        return Ok(result);
    }

    [Authorize(Roles = "admin")]
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
