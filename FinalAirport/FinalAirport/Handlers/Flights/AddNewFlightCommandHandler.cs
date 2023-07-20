using AutoMapper;
using FinalAirport.Commands.Flights;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Flights
{
    public class AddNewFlightCommandHandler : IRequestHandler<AddNewFlightCommand, ActionResponse>
    {
        private readonly IFlightRepository repository;
        private readonly IMapper mapper;

        public AddNewFlightCommandHandler(IFlightRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(AddNewFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = this.mapper.Map<Flight>(request);

            try
            {
                var result = await this.repository.CreateNewFlight(flight);

                return new ActionResponse() { Success=result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
