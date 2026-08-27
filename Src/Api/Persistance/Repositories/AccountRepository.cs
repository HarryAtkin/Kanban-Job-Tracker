using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class AccountRepository : IAccountRepository
{
    DBContext db;

    public AccountRepository(DBContext db)
    {
        this.db = db;
    }

    public async Task<Account?> Authenticate(Account account)
    {
        var result = await db.Account
            .Where(a =>
                (a.Email == account.Email) && (a.Password == account.Password))
            .FirstOrDefaultAsync();

        return result?.ToAccount;
    }

    public async Task<Account?> GetById(int id)
    {
        var account = await db.Account
            .Where (a => a.Id == id)
            .FirstOrDefaultAsync();
        return account?.ToAccount;
    }

    public async Task<Account?> GetByEmail(string email)
    {
        var account = await db.Account
            .Where(a => a.Email == email)
            .FirstOrDefaultAsync();
        return account?.ToAccount;
    }

    public async Task<IEnumerable<Account?>> Get()
    {
        var accounts = await db.Account
            .ToArrayAsync();

        return accounts.Select(a =>
        {
            a.Password = "";
            return a.ToAccount;
        }).ToList();
    }

    public async Task<Account> Create(Account account)
    {
        var accountEntity = new AccountEntity();
        accountEntity.Email = account.Email;
        accountEntity.FName = account.FName;
        accountEntity.LName = account.LName;
        accountEntity.Password = account.Password;
        accountEntity.CreatedAt = DateTime.UtcNow;
        accountEntity.IsAdmin = account.IsAdmin;
        await db.Account
            .AddAsync(accountEntity);
        await db.SaveChangesAsync();

        return accountEntity.ToAccount;
    }
}