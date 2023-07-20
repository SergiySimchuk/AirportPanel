using MediatR;

namespace FinalAirport.Commands.Tickets
{
    public class RemoveTicketCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
