using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Passengers
{
    public class RemovePassengerCommandHandler : IRequestHandler<RemovePassengerCommand, ActionResponse>
    {
        private readonly IPassengerRepository repository;
        private readonly IMapper mapper;

        public RemovePassengerCommandHandler(IPassengerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(RemovePassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = this.mapper.Map<Passenger>(request);

            try
            {
                var result = await this.repository.RemovePassenger(passenger);

                return new ActionResponse() { Success = result};
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
