using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    public async Task<AccountOutput> Authenticate(AccountInput accountInput)
    {
        var result = _accountService.Authenticate(accountInput);
        return await result;
    }

    [HttpPost("Create")]
    public async Task<AccountOutput> Create(AccountInput accountInput)
    {
        var result = _accountService.Create(accountInput);
        return await result;
    }
}
