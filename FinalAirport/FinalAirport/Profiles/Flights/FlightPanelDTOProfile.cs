using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Flights
{
    public class FlightPanelDTOProfile : Profile
    {
        public FlightPanelDTOProfile()
        {
            CreateMap<FlightsPanel, FlightPanelDTO>();
        }
    }
}
