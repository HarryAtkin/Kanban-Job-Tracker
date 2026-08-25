using Api.Services.models.mappers;
using System.Numerics;

namespace Api.Service;

public class LaneService : ILaneService
{
    ILaneRepository _laneRepository;
    LaneMapper _mapper;

    public LaneService(ILaneRepository repository)
    {
        _laneRepository = repository;
        _mapper = new LaneMapper();
    }

    public async Task<LaneOutput?> GetById(int id)
    {
        var lane = await _laneRepository.GetById(id);
        return lane != null ? _mapper.ToLaneOutput(lane) : null;
    }

    public async Task<IEnumerable<LaneOutput?>> GetByBoardId(int id)
    {
        var lane = await _laneRepository.GetByBoardId(id);
        return lane.Select(a => _mapper.ToLaneOutput(a)).ToList();
    }

    public async Task<IEnumerable<LaneOutput?>> Get()
    {
        var lane = await _laneRepository.Get();
        return lane.Select(a => _mapper.ToLaneOutput(a)).ToList();
    }

    public async Task<LaneOutput> Create(LaneInput lane)
    {
        var _lane = _mapper.ToLane(lane);
        _lane = await _laneRepository.Create(_lane);
        return _mapper.ToLaneOutput(_lane);
    }

}
