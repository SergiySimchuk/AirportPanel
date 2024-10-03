using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Passengers
{
    public class GetPassengersByUserCommand : IRequest<ICollection<Passenger>>
    {
        public int Id { get; set; }
    }
}
