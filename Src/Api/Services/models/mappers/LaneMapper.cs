namespace Api.Services.models.mappers
{
    public class LaneMapper
    {
        public LaneMapper() { }
        public Lane ToLane(LaneInput input)
        {
            return new Lane(null, input.Title, input.Description, input.BoardId, input.LaneOrder);
        }

        public LaneOutput ToLaneOutput(Lane input)
        {
            return new LaneOutput((int)input.Id, input.Title, input.Description, input.BoardId, input.LaneOrder);
        }
    }
}
