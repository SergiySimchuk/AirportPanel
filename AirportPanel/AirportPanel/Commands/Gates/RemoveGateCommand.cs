using MediatR;

namespace AirportPanel.Commands.Gates
{
    public class RemoveGateCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
