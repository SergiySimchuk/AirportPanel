using MediatR;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using FinalAirport.Commands.Airports;
using AutoMapper;

namespace FinalAirport.Handlers.Airports
{
    public class AddNewAirportCommandHandler : IRequestHandler<AddNewAirportCommand, ActionResponse>
    {
        private readonly IAirportRepository airportRepository;
        private IMapper mapper;

        public AddNewAirportCommandHandler(IAirportRepository airportRepository, IMapper mapper)
        {
            this.airportRepository = airportRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(AddNewAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = this.mapper.Map<Airport>(request);

            try
            {
                var result = await airportRepository.CreateNewAirport(airport);
                return new ActionResponse { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse { Success = false, Message = ex.Message };
            }
        }
    }
}
