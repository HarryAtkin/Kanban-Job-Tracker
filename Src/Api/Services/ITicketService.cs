namespace Api.Service;

public interface ITicketService
{
    public Task<TicketOutput?> GetById(int id);
    public Task<IEnumerable<TicketOutput?>> GetByFilter(TicketFilterInput input);
    public Task<IEnumerable<TicketOutput?>> Get();

    public Task<TicketOutput> Create(TicketInput account);

}
