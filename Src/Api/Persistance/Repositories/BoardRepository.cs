using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class BoardRepository : IBoardRepository
{
    DBContext db;

    public BoardRepository(DBContext db)
    {
        this.db = db;
    }

    public async Task<Board?> GetById(int id)
    {
        var board = await db.Board
            .Where (b => b.Id == id)
            .FirstOrDefaultAsync();
        return board?.ToBoard;
    }

    public async Task<IEnumerable<Board?>> GetByOwnerId(int id)
    {
        var board = await db.Board
            .Where(b => b.OwnerId == id)
            .ToListAsync();
        return board.Select(b => b.ToBoard);
    }

    public async Task<IEnumerable<Board?>> Get()
    {
        var board = await db.Board
            .ToArrayAsync();

        return board.Select(b => b.ToBoard).ToList();
    }

    public async Task<Board> Create(Board board)
    {
        var boardEntity = new BoardEntity();
        boardEntity.OwnerId = board.OwnerId;
        boardEntity.Title = board.Title;
        boardEntity.CreatedAt = DateTime.UtcNow;
        await db.Board
            .AddAsync(boardEntity);
        await db.SaveChangesAsync();

        return boardEntity.ToBoard;
    }
}