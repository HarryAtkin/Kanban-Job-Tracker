namespace Api.Services.models.mappers
{
    public class TicketMapper
    {
        public TicketMapper() { }
        public Ticket ToTicket(TicketInput input)
        {
            return new Ticket(null, input.CreatedById, input.AssignedToId, input.CreatedAt, input.TicketStatus, input.Title, input.Description, input.LaneId);
        }

        public TicketOutput ToTicketOutput(Ticket input)
        {
            return new TicketOutput((int)input.Id, input.CreatedById, input.AssignedToId, input.CreatedAt, input.TicketStatus, input.Title, input.Description, input.LaneId);
        }
    }
}
