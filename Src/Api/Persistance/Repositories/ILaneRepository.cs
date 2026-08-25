using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public interface ILaneRepository
{
    public Task<Lane?> GetById(int id);

    public Task<IEnumerable<Lane?>> GetByBoardId(int id);

    public Task<IEnumerable<Lane?>> Get();

    public Task<Lane> Create(Lane account);
}