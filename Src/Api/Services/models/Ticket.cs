
public class Ticket
{
    public int? Id { get; }

    public int CreatedById { get; set; }

    public int AssignedToId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string TicketStatus { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int LaneId { get; set; }

    public Ticket(int? id, int createdById, int assignedToId, DateTime createdAt, string ticketStatus, string title, string description, int laneId)
    {
        Id = id;
        CreatedById = createdById;
        AssignedToId = assignedToId;
        CreatedAt = createdAt;
        TicketStatus = ticketStatus;
        Title = title;
        Description = description;
        LaneId = laneId;
    }
}