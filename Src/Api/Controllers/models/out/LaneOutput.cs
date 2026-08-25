
public class LaneOutput
{
    public int? Id { get; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int BoardId { get; set; }

    public int LaneOrder { get; set; }

    public LaneOutput(int? id, string title, string description, int boardId, int laneOrder)
    {
        Id = id;
        Title = title;
        Description = description;
        BoardId = boardId;
        LaneOrder = laneOrder;
    }
}