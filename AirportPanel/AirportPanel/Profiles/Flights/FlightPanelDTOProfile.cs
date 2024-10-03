using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Flights
{
    public class FlightPanelDTOProfile : Profile
    {
        public FlightPanelDTOProfile()
        {
            CreateMap<FlightsPanel, FlightPanelDTO>();
        }
    }
}
