
public class TicketFilterInput
{
    public int? CreatedById { get; set; }

    public int? AssignedToId { get; set; }

    public string? TicketStatus { get; set; }

    public string? Title { get; set; }

    public int? LaneId { get; set; }

    public TicketFilterInput()
    {

    }

    public TicketFilterInput(int? createdById, int? assignedToId, string? ticketStatus, string? title, int? laneId)
    {
        CreatedById = createdById;
        AssignedToId = assignedToId;
        TicketStatus = ticketStatus;
        Title = title;
        LaneId = laneId;
    }
}