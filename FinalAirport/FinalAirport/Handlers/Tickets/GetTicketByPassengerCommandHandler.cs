using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Tickets
{
    public class GetTicketByPassengerCommandHandler : IRequestHandler<GetTicketsByPassengerCommand, ICollection<Ticket>>
    {
        private readonly ITicketRepository repository;
        private readonly IMapper mapper;

        public GetTicketByPassengerCommandHandler(ITicketRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public Task<ICollection<Ticket>> Handle(GetTicketsByPassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = this.mapper.Map<Passenger>(request);

            return this.repository.GetTicketsByPassenger(passenger);
        }
    }
}