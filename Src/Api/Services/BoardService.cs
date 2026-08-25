using Api.Services.models.mappers;

namespace Api.Service;

public class BoardService : IBoardService
{
    IBoardRepository _boardRepository;
    BoardMapper _mapper;

    public BoardService(IBoardRepository repository)
    {
        _boardRepository = repository;
        _mapper = new BoardMapper();
    }

    public async Task<BoardOutput?> GetById(int id)
    {
        var board = await _boardRepository.GetById(id);
        return board != null ? _mapper.ToBoardOutput(board) : null;
    }

    public async Task<BoardOutput?> GetByOwnerId(int id)
    {
        var board = await _boardRepository.GetByOwnerId(id);
        return board != null ? _mapper.ToBoardOutput(board) : null;
    }

    public async Task<IEnumerable<BoardOutput?>> Get()
    {
        var board = await _boardRepository.Get();
        return board.Select(a => _mapper.ToBoardOutput(a)).ToList();
    }

    public async Task<BoardOutput> Create(BoardInput board)
    {
        var _board = _mapper.ToBoard(board);
        _board = await _boardRepository.Create(_board);
        return _mapper.ToBoardOutput(_board);
    }

}
