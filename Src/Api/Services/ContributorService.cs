using Api.Services.models.mappers;
using System.Collections;

namespace Api.Service;

public class ContributorService : IContributorService
{
    IContributorRepository _contributorRepository;
    ContributorMapper _mapper;

    public ContributorService(IContributorRepository repository)
    {
        _contributorRepository = repository;
        _mapper = new ContributorMapper();
    }

    public async Task<ContributorOutput?> GetById(int id)
    {
        var contributor = await _contributorRepository.GetById(id);
        return contributor != null ? _mapper.ToContributorOutput(contributor) : null;
    }

    public async Task<IEnumerable<ContributorOutput?>> GetByAccountId(int id)
    {
        var contributor = await _contributorRepository.GetByAccountId(id);
        return contributor.Select(c => _mapper.ToContributorOutput(c)).ToList();
    }

    public async Task<IEnumerable<ContributorOutput?>> GetByBoardId(int id, int uid)
    {
        var boards = await GetByAccountId(uid);
        boards.Select(b => b.BoardId == id);

        if (boards.Any())
        {
            var contributor = await _contributorRepository.GetByBoardId(id);
            return contributor.Select(c => _mapper.ToContributorOutput(c)).ToList();
        }
        else
        {
            throw new UnauthorizedAccessException();
        }
    }

    public async Task<IEnumerable<ContributorOutput?>> Get()
    {
        var contributor = await _contributorRepository.Get();
        return contributor.Select(c => _mapper.ToContributorOutput(c)).ToList();
    }

    public async Task<ContributorOutput> Create(ContributorInput contributor)
    {
        var _contributor = _mapper.ToContributor(contributor);
        _contributor = await _contributorRepository.Create(_contributor);
        return _mapper.ToContributorOutput(_contributor);
    }
}
