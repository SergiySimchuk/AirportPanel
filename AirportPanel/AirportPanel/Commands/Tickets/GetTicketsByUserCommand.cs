using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Tickets
{
    public class GetTicketsByUserCommand : IRequest<ICollection<Ticket>>
    {
        public int Id { get; set; }
    }
}
