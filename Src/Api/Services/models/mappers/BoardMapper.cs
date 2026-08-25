namespace Api.Services.models.mappers
{
    public class BoardMapper
    {
        public BoardMapper() { }
        public Board ToBoard(BoardInput input)
        {
            return new Board(null, input.OwnerId, input.Title, input.CreatedAt);
        }

        public BoardOutput ToBoardOutput(Board input)
        {
            return new BoardOutput((int)input.Id, input.OwnerId, input.Title, input.CreatedAt);
        }
    }
}
