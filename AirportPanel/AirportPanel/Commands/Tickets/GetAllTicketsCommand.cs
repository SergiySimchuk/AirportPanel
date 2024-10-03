using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Tickets
{
    public class GetAllTicketsCommand : IRequest<ICollection<Ticket>>
    {
        
    }
}
