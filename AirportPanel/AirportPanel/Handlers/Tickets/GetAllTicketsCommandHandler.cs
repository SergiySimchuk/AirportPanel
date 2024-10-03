using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Tickets
{
    public class GetAllTicketsCommandHandler : IRequestHandler<GetAllTicketsCommand, ICollection<Ticket>>
    {
        private readonly ITicketRepository repository;

        public GetAllTicketsCommandHandler(ITicketRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<Ticket>> Handle(GetAllTicketsCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetAll();
        }
    }
}
