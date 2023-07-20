using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Gates
{
    public class RemoveGateCommandHandler : IRequestHandler<RemoveGateCommand, ActionResponse>
    {
        private readonly IGatesRepository gateRepository;
        private readonly IMapper mapper;

        public RemoveGateCommandHandler(IGatesRepository gateRepository, IMapper mapper)
        {
            this.gateRepository = gateRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(RemoveGateCommand request, CancellationToken cancellationToken)
        {
            var gate = this.mapper.Map<Gate>(request);

            try
            {
                var result = await gateRepository.RemoveGate(gate);

                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
