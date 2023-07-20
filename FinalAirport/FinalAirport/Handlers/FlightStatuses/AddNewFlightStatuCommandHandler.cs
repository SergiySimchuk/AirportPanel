using AutoMapper;
using FinalAirport.Commands.FlightStatuses;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.FlightStatuses
{
    public class AddNewFlightStatuCommandhandler : IRequestHandler<AddNewFlightStatusCommand, ActionResponse>
    {
        private readonly IFlightStatusRepository repository;
        private readonly IMapper mapper;

        public AddNewFlightStatuCommandhandler(IFlightStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ActionResponse> Handle(AddNewFlightStatusCommand request, CancellationToken cancellationToken)
        {
            var flightStatus = this.mapper.Map<FlightStatus>(request);

            try
            {
                var result = await this.repository.CreateNewFlightStatus(flightStatus);
                return new ActionResponse() {  Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
