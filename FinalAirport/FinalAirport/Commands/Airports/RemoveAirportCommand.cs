using MediatR;
namespace FinalAirport.Commands.Airports
{
    public class RemoveAirportCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
