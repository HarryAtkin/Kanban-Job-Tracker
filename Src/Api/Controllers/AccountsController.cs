using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{

    [HttpGet()]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
        })
        .ToArray();
    }

    [HttpGet()]
    public IEnumerable<WeatherForecast> GetByFilter()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
        })
        .ToArray();
    }

    [HttpGet("{$id: int}")]
    public IEnumerable<WeatherForecast> GetById(int id)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
        })
        .ToArray();
    }

}
