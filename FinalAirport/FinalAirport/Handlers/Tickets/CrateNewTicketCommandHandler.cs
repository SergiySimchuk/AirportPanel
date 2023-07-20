﻿using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Tickets
{
    public class CrateNewTicketCommandHandler : IRequestHandler<CreateTicketCommand, ActionResponse>
    {
        private readonly ITicketRepository repository;
        private readonly IMapper mapper;

        public CrateNewTicketCommandHandler(ITicketRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ActionResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = this.mapper.Map<Ticket>(request);

            try
            {
                var result = await this.repository.CreateNewTicket(ticket);
                return new ActionResponse() { Success = result };
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
