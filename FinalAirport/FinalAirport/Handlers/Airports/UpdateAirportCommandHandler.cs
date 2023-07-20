using AutoMapper;
using FinalAirport.Commands.Airports;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Airports
{
    public class UpdateAirportCommandHandler : IRequestHandler<UpdateAirportCommand, ActionResponse>
    {
        private IAirportRepository airportRepository; private IMapper mapper;

        public UpdateAirportCommandHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            this.airportRepository = airportRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = this.mapper.Map<Airport>(request);

            try
            {
                var result = await airportRepository.UpdateAirport(airport);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
