using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Flights
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, ActionResponse>
    {
        private readonly IFlightRepository repository;
        private readonly IMapper mapper;

        public UpdateFlightCommandHandler(IFlightRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = this.mapper.Map<Flight>(request);
            try
            {
                var result = await this.repository.UpdadeFlight(flight);
                return new ActionResponse() { Success = result  };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success =false, Message = ex.Message };
            }
        }
    }
}
