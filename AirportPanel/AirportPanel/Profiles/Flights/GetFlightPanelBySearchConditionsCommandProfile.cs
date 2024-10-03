using AutoMapper;
using AirportPanel.Commands.Flights;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Flights
{
    public class GetFlightPanelBySearchConditionsCommandProfile : Profile
    {
        public GetFlightPanelBySearchConditionsCommandProfile()
        {
            CreateMap<FlightSearchConditions, GetFlightPanelBySearchConditionsCommand>();
        }
    }
}
