namespace Api.Service;

public interface IAccountService
{
    //public Task<bool> Authenticate(Account account);

    public Task<AccountOutput> Authenticate(AccountInput account);

    public Task<AccountOutput?> GetById(int id);
    public Task<AccountOutput?> GetByEmail(string email);
    public Task<IEnumerable<AccountOutput?>> Get();

    public Task<AccountOutput?> Create(AccountInput account);

}
