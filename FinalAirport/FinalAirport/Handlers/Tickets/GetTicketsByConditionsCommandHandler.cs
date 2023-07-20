using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Tickets
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
