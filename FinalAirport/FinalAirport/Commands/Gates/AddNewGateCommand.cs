using MediatR;

namespace FinalAirport.Commands.Gates
{
    public class AddNewGateCommand : IRequest<ActionResponse>
    {
        public string Name { get; set; }
        public int TerminalID { get; set; }
    }
}
