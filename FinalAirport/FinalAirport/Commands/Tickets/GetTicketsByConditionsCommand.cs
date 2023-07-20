using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Tickets
{
    public class GetTicketsByConditionsCommand : IRequest<ICollection<Ticket>>
    {
        public string FlightNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
    }
}
