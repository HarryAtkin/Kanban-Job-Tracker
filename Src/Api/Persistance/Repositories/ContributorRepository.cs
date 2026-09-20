using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class ContributorRepository : IContributorRepository
{
    DBContext db;

    public ContributorRepository(DBContext db)
    {
        this.db = db;
    }

    public async Task<Contributor?> GetById(int id)
    {
        var contributor = await db.Contributor
            .Where (c => c.Id == id)
            .FirstOrDefaultAsync();
        return contributor?.ToContributor;
    }

    public async Task<IEnumerable<Contributor?>> GetByAccountId(int id)
    {
        var contributor = await db.Contributor
            .Where(c => c.AccountId == id)
            .ToListAsync();
        return contributor.Select(c => c.ToContributor);
    }

    public async Task<IEnumerable<Contributor?>> GetByBoardId(int id)
    {
        var contributor = await db.Contributor
            .Where(c => c.BoardId == id)
            .ToArrayAsync();

        return contributor.Select(c => c.ToContributor).ToList();
    }

    public async Task<IEnumerable<Contributor?>> Get()
    {
        var contributor = await db.Contributor
            .ToArrayAsync();

        return contributor.Select(c => c.ToContributor).ToList();
    }

    public async Task<Contributor> Create(Contributor contributor)
    {
        var contributorEntity = new ContributorEntity();
        contributorEntity.BoardId = contributor.BoardId;
        contributorEntity.AccountId = contributor.AccountId;
        contributorEntity.PermissionType = contributor.PermissionType;

        await db.Contributor
            .AddAsync(contributorEntity);
        await db.SaveChangesAsync();

        return contributorEntity.ToContributor;
    }
}