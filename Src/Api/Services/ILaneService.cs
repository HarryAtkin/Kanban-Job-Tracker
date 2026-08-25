namespace Api.Service;

public interface ILaneService
{
    public Task<LaneOutput?> GetById(int id);
    public Task<IEnumerable<LaneOutput?>> GetByBoardId(int id);
    public Task<IEnumerable<LaneOutput?>> Get();

    public Task<LaneOutput> Create(LaneInput account);

}
