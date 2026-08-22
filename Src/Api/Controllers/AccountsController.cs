using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{

    [HttpGet()]
    public string Get()
    {
        return "Hello world";
    }

    //[HttpGet()]
    //public IEnumerable<Account> GetByFilter()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new Account
    //    {
    //    })
    //    .ToArray();
    //}

    //[HttpGet("{$id: int}")]
    //public IEnumerable<Account> GetById(int id)
    //{
    //    return Enumerable.Range(1, 5).Select(index => new Account
    //    {
    //    })
    //    .ToArray();
    //}

}
