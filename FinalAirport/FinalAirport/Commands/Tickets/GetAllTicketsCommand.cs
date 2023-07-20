using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Tickets
{
    public class GetAllTicketsCommand : IRequest<ICollection<Ticket>>
    {
        
    }
}
