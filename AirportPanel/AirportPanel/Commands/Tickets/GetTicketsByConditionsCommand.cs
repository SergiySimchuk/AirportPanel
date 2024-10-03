using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Tickets
{
    public class GetTicketsByConditionsCommand : IRequest<ICollection<Ticket>>
    {
        public string FlightNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
    }
}
