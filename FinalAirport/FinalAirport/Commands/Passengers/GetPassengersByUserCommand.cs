using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Passengers
{
    public class GetPassengersByUserCommand : IRequest<ICollection<Passenger>>
    {
        public int Id { get; set; }
    }
}
