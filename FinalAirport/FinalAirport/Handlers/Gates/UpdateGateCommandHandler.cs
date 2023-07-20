using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Gates
{
    public class UpdateGateCommandHandler : IRequestHandler<UpdateGateCommand, ActionResponse>
    {
        private readonly IGatesRepository gatesRepository;
        private readonly IMapper mapper;
        public UpdateGateCommandHandler(IGatesRepository gatesRepository, IMapper mapper)
        {
            this.gatesRepository = gatesRepository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdateGateCommand request, CancellationToken cancellationToken)
        {
            var gate = this.mapper.Map<Gate>(request);

            try
            {
                var result = await gatesRepository.UpdateGate(gate);

                return new ActionResponse() { Success = result };

            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
