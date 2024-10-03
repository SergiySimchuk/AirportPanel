using MediatR;

namespace AirportPanel.Commands.Passengers
{
    public class RemovePassengerCommand : IRequest<ActionResponse> 
    {
        public int Id { get; set; }
    }
}
