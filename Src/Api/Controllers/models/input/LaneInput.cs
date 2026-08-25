
public class LaneInput
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int BoardId { get; set; }

    public int LaneOrder { get; set; }

    public LaneInput(string title, string description, int boardId, int laneOrder)
    {
        Title = title;
        Description = description;
        BoardId = boardId;
        LaneOrder = laneOrder;
    }
}