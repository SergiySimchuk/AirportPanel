using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Passengers
{
    public class GetPassengerByIDCommand : IRequest<Passenger>
    {
        public int Id { get; set; }
    }
}
