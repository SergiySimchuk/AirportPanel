using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Tickets
{
    public class GetTicketsByConditionsCommandHandler : IRequestHandler<GetTicketsByConditionsCommand, ICollection<Ticket>>
    {
        private readonly ITicketRepository repository;

        public GetTicketsByConditionsCommandHandler(ITicketRepository repository)
        {
            this.repository = repository;
        }
        public Task<ICollection<Ticket>> Handle(GetTicketsByConditionsCommand request, CancellationToken cancellationToken)
        {
            return this.repository.GetTicketsByConditions(request.FlightNumber, request.FirstName, request.LastName, request.Passport);
        }
    }
}
