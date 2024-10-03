using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Tickets
{
    public class GetTicketsByPassengerCommand : IRequest<ICollection<Ticket>>
    {
        public int Id { get; set; }
    }
}
