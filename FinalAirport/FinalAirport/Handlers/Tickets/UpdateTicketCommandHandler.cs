using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Tickets
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, ActionResponse>
    {
        private readonly ITicketRepository repository;
        private readonly IMapper mapper;
        public UpdateTicketCommandHandler(ITicketRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = this.mapper.Map<Ticket>(request);

            try
            {
                var result = await repository.UpdateTicket(ticket);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
