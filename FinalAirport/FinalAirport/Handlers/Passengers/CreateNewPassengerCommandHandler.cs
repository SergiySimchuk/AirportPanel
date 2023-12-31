﻿using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using MediatR;

namespace FinalAirport.Handlers.Passengers
{
    public class CreateNewPassengerCommandHandler : IRequestHandler<CreateNewPassengerCommand, Passenger>
    {
        private readonly IPassengerRepository repository;
        private readonly IMapper mapper;

        public CreateNewPassengerCommandHandler(IPassengerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Passenger> Handle(CreateNewPassengerCommand request, CancellationToken cancellationToken)
        {
            var passenger = this.mapper.Map<Passenger>(request);

            try
            {
                var result = await this.repository.CreateNewPassenger(passenger);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
