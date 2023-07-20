using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Terminals
{
    public class AddNewTerminalCommandHandler : IRequestHandler<AddNewTerminalCommand, ActionResponse>
    {
        private readonly ITerminalRepository terminalRepository;
        private readonly IMapper mapper;

        public AddNewTerminalCommandHandler(ITerminalRepository terminalRepository, IMapper mapper)
        {
            this.terminalRepository = terminalRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(AddNewTerminalCommand request, CancellationToken cancellationToken)
        {
            var terminal = this.mapper.Map<Terminal>(request);

            try
            {
                var result = await terminalRepository.CreateNewTerminal(terminal);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
