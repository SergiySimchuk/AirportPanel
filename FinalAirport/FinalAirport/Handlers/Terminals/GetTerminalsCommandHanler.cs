using FinalAirport.Commands.Terminals;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Terminals
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
