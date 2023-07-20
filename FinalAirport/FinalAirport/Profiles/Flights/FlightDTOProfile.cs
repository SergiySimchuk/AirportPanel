using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Flights
{
    public class FlightDTOProfile : Profile
    {
        public FlightDTOProfile()
        {
            CreateMap<Flight, FlightDTO>();
        }
    }
}
