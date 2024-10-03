using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Flights
{
    public class FlightDTOProfile : Profile
    {
        public FlightDTOProfile()
        {
            CreateMap<Flight, FlightDTO>();
        }
    }
}
