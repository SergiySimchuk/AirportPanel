using MediatR;

namespace FinalAirport.Commands.Passengers
{
    public class RemovePassengerCommand : IRequest<ActionResponse> 
    {
        public int Id { get; set; }
    }
}
