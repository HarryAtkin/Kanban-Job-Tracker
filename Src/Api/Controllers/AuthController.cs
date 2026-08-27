using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IAccountService _accountService;
    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Authenticate")]
    public async Task<ActionResult<AccountOutput>> Authenticate(AccountInput accountInput)
    {
        var result = await _accountService.Authenticate(accountInput);
        return result != null ? Ok(result) : Unauthorized();
    }

    [HttpPost("Create")]
    public async Task<ActionResult<AccountOutput>> Create(AccountInput accountInput)
    {
        var result = await _accountService.Create(accountInput);
        return Ok(result);
    }
}
