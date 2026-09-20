using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public interface IContributorRepository
{
    public Task<Contributor?> GetById(int id);

    public Task<IEnumerable<Contributor?>> GetByAccountId(int id);

    public Task<IEnumerable<Contributor?>> GetByBoardId(int id);

    public Task<IEnumerable<Contributor?>> Get();

    public Task<Contributor> Create(Contributor contributor);
}