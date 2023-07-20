using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Airports
{
    public class AddNewAirportCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
