using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Tickets
{
    public class GetTicketsByUserCommanHandler : IRequestHandler<GetTicketsByUserCommand, ICollection<Ticket>>
    {
        private readonly ITicketRepository repository;
        private readonly IMapper mapper;

        public GetTicketsByUserCommanHandler(ITicketRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ICollection<Ticket>> Handle(GetTicketsByUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);

            return await this.repository.GetTicketsByUser(user);
        }
    }
}