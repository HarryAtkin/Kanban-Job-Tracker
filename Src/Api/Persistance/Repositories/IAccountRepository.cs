using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public interface IAccountRepository
{
    public Task<Account?> Authenticate(Account account);

    public Task<Account?> GetById(int id);

    public Task<Account?> GetByEmail(string email);

    public Task<IEnumerable<Account>> Get();

    public Task<Account> Create(Account account);
}