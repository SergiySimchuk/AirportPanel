using AutoMapper;
using AirportPanel.Commands.Passengers;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Passengers
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
