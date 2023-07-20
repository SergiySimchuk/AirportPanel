using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Passengers
{
    public class UpdatePassengerCommandHandler : IRequestHandler<UpdatePassengerCommand, Passenger>
    {
        private readonly IPassengerRepository repository;
        private readonly IMapper mapper;
        public UpdatePassengerCommandHandler(IPassengerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Passenger> Handle(UpdatePassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = this.mapper.Map<Passenger>(request);

            try
            {
                var result = await this.repository.UpdatePassenger(passenger);
                return passenger;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
