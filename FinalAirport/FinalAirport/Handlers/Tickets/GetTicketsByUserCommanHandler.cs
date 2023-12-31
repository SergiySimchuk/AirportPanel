﻿using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Tickets
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