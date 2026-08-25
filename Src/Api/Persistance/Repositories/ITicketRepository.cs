using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public interface ITicketRepository
{
    public Task<Ticket?> GetById(int id);
    public Task<IEnumerable<Ticket?>> GetByFilter(int? createdById, int? assignedToId, string? ticketStatus, string? title, int? laneId);
    public Task<IEnumerable<Ticket?>> Get();

    public Task<Ticket> Create(Ticket ticket);
}