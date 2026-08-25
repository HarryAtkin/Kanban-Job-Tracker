using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Api.Service;

public class TicketRepository : ITicketRepository
{
    DBContext db;

    public TicketRepository(DBContext db)
    {
        this.db = db;
    }

    public async Task<Ticket?> GetById(int id)
    {
        var ticket = await db.Ticket
            .Where (b => b.Id == id)
            .FirstOrDefaultAsync();

        return ticket?.ToTicket;
    }

    public async Task<IEnumerable<Ticket?>> GetByFilter(int? createdById, int? assignedToId, string? ticketStatus, string? title, int? laneId)
    {
        var query = db.Ticket
            .AsNoTracking()
            .AsQueryable();

        if (createdById != null) query = query.Where(t => t.CreatedById == createdById);
        if (assignedToId != null) query = query.Where(t => t.AssignedToId == assignedToId);
        if (!string.IsNullOrEmpty(ticketStatus)) query.Where(t => t.TicketStatus == ticketStatus);
        if (!string.IsNullOrEmpty(title)) query.Where(t => t.Title == title);
        if (laneId != null) query = query.Where(t => t.LaneId == laneId);

        var ticket = await query.ToListAsync();
        return ticket.Select(b => b.ToTicket).ToList();
    }

    public async Task<IEnumerable<Ticket?>> Get()
    {
        var ticket = await db.Ticket
            .ToArrayAsync();

        return ticket.Select(b => b.ToTicket).ToList();
    }

    public async Task<Ticket> Create(Ticket ticket)
    {
        var ticketEntity = new TicketEntity();
        ticketEntity.CreatedById = ticket.CreatedById;
        ticketEntity.AssignedToId = ticket.AssignedToId;
        ticketEntity.CreatedAt = DateTime.UtcNow;
        ticketEntity.TicketStatus = ticket.TicketStatus;
        ticketEntity.Title = ticket.Title;
        ticketEntity.Description = ticket.Description;
        ticketEntity.LaneId = ticket.LaneId;

        await db.Ticket
            .AddAsync(ticketEntity);
        await db.SaveChangesAsync();

        return ticketEntity.ToTicket;
    }
}