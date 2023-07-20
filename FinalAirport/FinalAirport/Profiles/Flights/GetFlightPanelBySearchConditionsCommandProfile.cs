using AutoMapper;
using FinalAirport.Commands.Flights;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Flights
{
    public class GetFlightPanelBySearchConditionsCommandProfile : Profile
    {
        public GetFlightPanelBySearchConditionsCommandProfile()
        {
            CreateMap<FlightSearchConditions, GetFlightPanelBySearchConditionsCommand>();
        }
    }
}
