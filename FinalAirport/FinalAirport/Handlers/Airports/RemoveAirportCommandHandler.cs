using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Airports
{
    public class RemoveAirportCommandHandler : IRequestHandler<RemoveAirportCommand, ActionResponse>
    {
        private readonly IAirportRepository airportRepository;
        private IMapper mapper;

        public RemoveAirportCommandHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            this.airportRepository = airportRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(RemoveAirportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var airport = this.mapper.Map<Airport>(request);
                var result = await airportRepository.DeleteAirport(airport);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
