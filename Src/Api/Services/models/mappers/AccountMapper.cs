namespace Api.Services.models.mappers
{
    public class AccountMapper
    {
        public AccountMapper() { }
        public Account ToAccount(AccountInput input)
        {
            return new Account(null, input.FName, input.LName, input.Email, input.Password, input.IsNew);
        }

        public AccountOutput ToAccountOutput(Account input)
        {
            return new AccountOutput((int)input.Id, input.FName, input.LName, input.Email, input.Password, input.CreatedAt, input.Token);
        }
    }
}
