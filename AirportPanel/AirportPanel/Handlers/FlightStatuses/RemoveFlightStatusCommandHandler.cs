using AutoMapper;
using AirportPanel.Commands.FlightStatuses;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.FlightStatuses
{
    public class RemoveFlightStatusCommandHandler : IRequestHandler<RemoveFlightStatusCommand, ActionResponse>
    {
        private readonly IFlightStatusRepository repository;
        private readonly IMapper mapper;

        public RemoveFlightStatusCommandHandler(IFlightStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(RemoveFlightStatusCommand request, CancellationToken cancellationToken)
        {
            var flightStatus = this.mapper.Map<FlightStatus>(request);

            try
            {
                var result = await this.repository.RemoveFlightStatus(flightStatus);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
