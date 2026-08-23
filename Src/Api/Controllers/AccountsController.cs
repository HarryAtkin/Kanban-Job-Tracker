using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("{id:int}")]
    public async Task<AccountOutput> GetById(int id)
    {
        var result = _accountService.GetById(id);
        return await result;
    }

    [HttpGet("GetByEmail")]
    public async Task<AccountOutput> GetByEmail(string email)
    {
        var result = _accountService.GetByEmail(email);
        return await result;
    }

    [HttpGet()]
    public async Task<IEnumerable<AccountOutput?>> Get()
    {
        var result = _accountService.Get();
        return await result;
    }
}
