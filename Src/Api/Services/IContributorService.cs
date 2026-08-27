namespace Api.Service;

public interface IContributorService
{
    public Task<ContributorOutput?> GetById(int id);
    public Task<ContributorOutput?> GetByAccountId(int id);
    public Task<IEnumerable<ContributorOutput?>> GetByBoardId(int id, int uid);
    public Task<IEnumerable<ContributorOutput?>> Get();

    public Task<ContributorOutput> Create(ContributorInput account);

}
