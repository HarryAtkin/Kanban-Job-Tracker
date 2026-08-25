using Api.Services.models.mappers;

namespace Api.Service;

public class TicketService : ITicketService
{
    ITicketRepository _ticketRepository;
    TicketMapper _mapper;

    public TicketService(ITicketRepository repository)
    {
        _ticketRepository = repository;
        _mapper = new TicketMapper();
    }

    public async Task<TicketOutput?> GetById(int id)
    {
        var ticket = await _ticketRepository.GetById(id);
        return ticket != null ? _mapper.ToTicketOutput(ticket) : null;
    }

    public async Task<IEnumerable<TicketOutput?>> GetByFilter(TicketFilterInput input)
    {
        var ticket = await _ticketRepository.GetByFilter(input.CreatedById, input.AssignedToId, input.TicketStatus, input.Title, input.LaneId);
        return ticket.Select(t => _mapper.ToTicketOutput(t)).ToList();
    }

    public async Task<IEnumerable<TicketOutput?>> Get()
    {
        var ticket = await _ticketRepository.Get();
        return ticket.Select(a => _mapper.ToTicketOutput(a)).ToList();
    }

    public async Task<TicketOutput> Create(TicketInput ticket)
    {
        var _ticket = _mapper.ToTicket(ticket);
        _ticket = await _ticketRepository.Create(_ticket);
        return _mapper.ToTicketOutput(_ticket);
    }
}
