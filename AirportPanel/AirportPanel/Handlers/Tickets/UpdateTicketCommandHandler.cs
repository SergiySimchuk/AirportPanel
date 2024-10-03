using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using MediatR;

namespace AirportPanel.Handlers.Tickets
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
