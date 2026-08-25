
public class TicketInput
{
    public int CreatedById { get; set; }

    public int AssignedToId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string TicketStatus { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int LaneId { get; set; }

    public TicketInput(int createdById, int assignedToId, DateTime createdAt, string ticketStatus, string title, string description, int laneId)
    {
        CreatedById = createdById;
        AssignedToId = assignedToId;
        CreatedAt = createdAt;
        TicketStatus = ticketStatus;
        Title = title;
        Description = description;
        LaneId = laneId;
    }
}