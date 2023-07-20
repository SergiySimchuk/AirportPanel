using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Tickets
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
