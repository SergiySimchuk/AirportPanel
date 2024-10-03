using AirportPanel.Domain;
using MediatR;
namespace AirportPanel.Commands.Airports
{
    public class GetAirportsCommand : IRequest<ICollection<Airport>>
    {
    }
}
