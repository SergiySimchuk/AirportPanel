﻿using FinalAirport.Commands.Flights;
using FinalAirport.Domain;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Flights
{
    public class GetFlightPanelBySearchConditionsHandler : IRequestHandler<GetFlightPanelBySearchConditionsCommand, ICollection<FlightsPanel>>
    {
        private readonly IFlightsPanelRepository repository;

        public GetFlightPanelBySearchConditionsHandler(IFlightsPanelRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<FlightsPanel>> Handle(GetFlightPanelBySearchConditionsCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.GetCollectionWithCondition(request.FlightNumber, request.DepartureAirport, request.ArrivalAirport, request.StartDate, request.EndDate);
        }
    }
}
