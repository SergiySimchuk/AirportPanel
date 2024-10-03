using MediatR;
namespace AirportPanel.Commands.Airports
{
    public class RemoveAirportCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
