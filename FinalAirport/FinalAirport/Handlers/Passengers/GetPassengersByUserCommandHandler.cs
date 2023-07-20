using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Passengers
{
    public class GetPassengersByUserCommandHandler : IRequestHandler<GetPassengersByUserCommand, ICollection<Passenger>>
    {
        private readonly IPassengerRepository repository;
        private readonly IMapper mapper;

        public GetPassengersByUserCommandHandler(IPassengerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ICollection<Passenger>> Handle(GetPassengersByUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);

            return await this.repository.GetPassengersByUser(user);
        }
    }
}
