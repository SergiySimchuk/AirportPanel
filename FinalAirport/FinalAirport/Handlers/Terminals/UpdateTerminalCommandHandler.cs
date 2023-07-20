using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Terminals
{
    public class UpdateTerminalCommandHandler : IRequestHandler<UpdateTerminalCommand, ActionResponse>
    {
        private readonly ITerminalRepository terminalRepository;
        private readonly IMapper mapper;

        public UpdateTerminalCommandHandler(ITerminalRepository terminalRepository, IMapper mapper)
        {
            this.terminalRepository = terminalRepository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdateTerminalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var terminal = this.mapper.Map<Terminal>(request);
                var result = await terminalRepository.UpdateTerminal(terminal);

                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
