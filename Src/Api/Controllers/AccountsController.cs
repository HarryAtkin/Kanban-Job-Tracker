using Api.Controllers.util;
using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private IAccountService _accountService;
    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet()]
    public async Task<ActionResult<AccountOutput>> GetById()
    {
        var result = await _accountService.GetById(User.GetUserId());
        return result != null ? Ok(result) : NotFound();
    }

    [Authorize(Roles = "admin")]
    [HttpGet("{id:int}")] //Admin entrance point
    public async Task<ActionResult<AccountOutput>> GetById(int id)
    {
        var result = await _accountService.GetById(id);
        return result != null ? Ok(result) : NotFound();
    }

    [Authorize(Roles = "admin")]
    [HttpGet("GetByEmail")] //Admin entrance point
    public async Task<ActionResult<AccountOutput>> GetByEmail(string email)
    {
        var result = await _accountService.GetByEmail(email);
        return result != null ? Ok(result) : NotFound();
    }

    [Authorize(Roles = "admin")]
    [HttpGet()] //Admin entrance point
    public async Task<ActionResult<IEnumerable<AccountOutput?>>> Get()
    {
        var result = await _accountService.Get();
        return Ok(result);
    }
}
