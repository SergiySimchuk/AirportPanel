using MediatR;
using AirportPanel.Domain;
using AirportPanel.Infrastructure;
using AirportPanel.Commands.Airports;
using AutoMapper;

namespace AirportPanel.Handlers.Airports
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
