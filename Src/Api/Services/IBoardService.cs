namespace Api.Service;

public interface IBoardService
{
    public Task<BoardOutput?> GetById(int id);
    public Task<IEnumerable<BoardOutput?>> GetByOwnerId(int id);
    public Task<IEnumerable<BoardOutput?>> Get();

    public Task<BoardOutput> Create(BoardInput account);

}
