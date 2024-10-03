using AirportPanel.Domain;
using MediatR;

namespace AirportPanel.Commands.Passengers
{
    public class GetPassengerByIDCommand : IRequest<Passenger>
    {
        public int Id { get; set; }
    }
}
