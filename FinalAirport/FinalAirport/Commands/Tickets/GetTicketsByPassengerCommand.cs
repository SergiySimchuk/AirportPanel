using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Tickets
{
    public class GetTicketsByPassengerCommand : IRequest<ICollection<Ticket>>
    {
        public int Id { get; set; }
    }
}
