using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Terminals
{
    public class RemoveTerminalCommandHandler : IRequestHandler<RemoveTerminalCommand, ActionResponse>
    {
        private readonly ITerminalRepository terminalRepository;
        private readonly IMapper mapper;

        public RemoveTerminalCommandHandler(ITerminalRepository terminalRepository, IMapper mapper)
        {
            this.terminalRepository = terminalRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(RemoveTerminalCommand request, CancellationToken cancellationToken)
        {
            var terminal = this.mapper.Map<Terminal>(request);

            try
            {
                var result = await terminalRepository.RemoveTerminal(terminal);

                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
