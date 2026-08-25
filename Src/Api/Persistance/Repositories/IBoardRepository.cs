using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public interface IBoardRepository
{
    public Task<Board?> GetById(int id);

    public Task<IEnumerable<Board?>> GetByOwnerId(int id);

    public Task<IEnumerable<Board?>> Get();

    public Task<Board> Create(Board account);
}