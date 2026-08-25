
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ticket")]
[PrimaryKey(nameof(Id))]
public class TicketEntity
{
    [Column("id")]
    public int? Id { get; }

    [Column("created_by_id")]
    public int CreatedById { get; set; }

    [Column("assigned_to_id")]
    public int AssignedToId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("ticket_status")]
    public string TicketStatus { get; set; } //Make into enum

    [Column("title")]
    public string Title { get; set; }

    [Column("ticket_description")]
    public string Description { get; set; }

    [Column("lane_id")]
    public int LaneId { get; set; }

    public TicketEntity()
    {

    }

    public TicketEntity(int? id, int createdById, int assignedToId, DateTime createdAt, string ticketStatus, string title, string description, int laneId)
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

    public Ticket ToTicket => new Ticket(
        id: Id,
        createdById: CreatedById,
        assignedToId: AssignedToId,
        createdAt: CreatedAt,
        ticketStatus: TicketStatus,
        title: Title,
        description: Description,
        laneId: LaneId
    );
}