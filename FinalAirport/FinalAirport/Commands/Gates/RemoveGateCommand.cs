using MediatR;

namespace FinalAirport.Commands.Gates
{
    public class RemoveGateCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
