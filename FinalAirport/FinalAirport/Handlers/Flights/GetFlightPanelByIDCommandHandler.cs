﻿using FinalAirport.Commands.Flights;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Flights
{
    public class GetFlightPanelByIDCommandHandler : IRequestHandler<GetFlightPanelByIDCommand, FlightsPanel>
    {
        private readonly IFlightsPanelRepository repository;


        public GetFlightPanelByIDCommandHandler(IFlightsPanelRepository repository)
        {
            this.repository = repository;
        }
        public async Task<FlightsPanel> Handle(GetFlightPanelByIDCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetFlightPanelById(request.Id);
        }
    }
}
