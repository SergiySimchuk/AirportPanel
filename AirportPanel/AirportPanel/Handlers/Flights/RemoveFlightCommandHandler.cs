using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Flights
{
    public class RemoveFlightCommandHandler : IRequestHandler<RemoveFlightCommand, ActionResponse>
    {
        private readonly IFlightRepository repository;
        private readonly IMapper mapper;

        public RemoveFlightCommandHandler(IFlightRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(RemoveFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = this.mapper.Map<Flight>(request);

            try
            {
                var result = await this.repository.RemoveFlight(flight);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
