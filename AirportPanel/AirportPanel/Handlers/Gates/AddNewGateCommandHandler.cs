using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using MediatR;

namespace AirportPanel.Handlers.Gates
{
    public class AddNewGateCommandHandler : IRequestHandler<AddNewGateCommand, ActionResponse>
    {
        private readonly IGatesRepository gatesRepository;
        private readonly IMapper mapper;

        public AddNewGateCommandHandler(IGatesRepository gatesRepository, IMapper mapper)
        {
            this.gatesRepository = gatesRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(AddNewGateCommand request, CancellationToken cancellationToken)
        {
            var gate = this.mapper.Map<Gate>(request);
            
            try
            {
                var result = await gatesRepository.CreateNewGate(gate);

                return new ActionResponse() { Success = result };

            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
