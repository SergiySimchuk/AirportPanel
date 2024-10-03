using AirportPanel.Commands.Terminals;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Terminals
{
    public class GetTerminalsCommandHanler : IRequestHandler<GetTerminalsCommand, ICollection<Terminal>>
    {
        private readonly ITerminalRepository terminalRepository;

        public GetTerminalsCommandHanler(ITerminalRepository terminalRepository)
        {
            this.terminalRepository = terminalRepository;
        }

        public async Task<ICollection<Terminal>> Handle(GetTerminalsCommand request, CancellationToken cancellationToken)
        {
            return await terminalRepository.GetAll();
        }
    }
}
