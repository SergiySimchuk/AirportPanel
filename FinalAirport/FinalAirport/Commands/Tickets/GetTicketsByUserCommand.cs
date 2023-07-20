using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Tickets
{
    public class GetTicketsByUserCommand : IRequest<ICollection<Ticket>>
    {
        public int Id { get; set; }
    }
}
