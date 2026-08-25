using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class LaneRepository : ILaneRepository
{
    DBContext db;

    public LaneRepository(DBContext db)
    {
        this.db = db;
    }

    public async Task<Lane?> GetById(int id)
    {
        var lane = await db.Lane
            .Where (b => b.Id == id)
            .FirstOrDefaultAsync();
        return lane?.ToLane;
    }

    public async Task<IEnumerable<Lane?>> GetByBoardId(int id)
    {
        var lane = await db.Lane
            .Where(b => b.BoardId == id)
            .ToListAsync();

        return lane.Select(b => b.ToLane).ToList();
    }

    public async Task<IEnumerable<Lane?>> Get()
    {
        var lane = await db.Lane
            .ToArrayAsync();

        return lane.Select(b => b.ToLane).ToList();
    }

    public async Task<Lane> Create(Lane lane)
    {
        var laneEntity = new LaneEntity();
        laneEntity.Title = lane.Title;
        laneEntity.Description = lane.Description;
        laneEntity.BoardId = lane.BoardId;
        laneEntity.LaneOrder = lane.LaneOrder;

        await db.Lane
            .AddAsync(laneEntity);
        await db.SaveChangesAsync();

        return laneEntity.ToLane;
    }
}