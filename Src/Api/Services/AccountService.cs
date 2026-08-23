using Api.Services.models.mappers;
using DotNetEnv;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Api.Service;

public class AccountService: IAccountService
{
    IAccountRepository _accountRepository;
    AccountMapper _mapper;

    public AccountService(IAccountRepository repository)
    {
        _accountRepository = repository;
        _mapper = new AccountMapper();
    }

    public async Task<AccountOutput> Authenticate(AccountInput account)
    {
        var _account = _mapper.ToAccount(account);
        _account = await _accountRepository.Authenticate(_account);
        if(_account != null)
        {
            _account.Token = GenerateToken(_account);
            return _mapper.ToAccountOutput(_account);
        }
        throw new NotImplementedException();
    }

    public async Task<AccountOutput?> GetById(int id)
    {
        var account = await _accountRepository.GetById(id);
        return account != null ? _mapper.ToAccountOutput(account) : null;

    }

    public async Task<AccountOutput?> GetByEmail(string email)
    {
        var account = await _accountRepository.GetByEmail(email);
        return account != null ? _mapper.ToAccountOutput(account) : null;
    }

    public async Task<IEnumerable<AccountOutput?>> Get()
    {
        var account = await _accountRepository.Get();
        return account.Select(a => _mapper.ToAccountOutput(a)).ToList();
    }

    public async Task<AccountOutput> Create(AccountInput account)
    {
        var _account = _mapper.ToAccount(account);
        _account = await _accountRepository.Create(_account);
        _account.Token = GenerateToken(_account);
        return _mapper.ToAccountOutput(_account);
    }

    private string GenerateToken(Account account)
    {
        Env.Load();
        var Secret = Environment.GetEnvironmentVariable("Secret");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int accountId = (int) account.Id;

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, accountId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, account.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
