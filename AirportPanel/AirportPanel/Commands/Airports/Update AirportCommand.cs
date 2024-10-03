using MediatR;

namespace AirportPanel.Commands.Airports
{
    public class UpdateAirportCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
