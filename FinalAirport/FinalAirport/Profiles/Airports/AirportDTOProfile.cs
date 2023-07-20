using AutoMapper;
using FinalAirport.Domain;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Airports
{
    public class AirportDTOProfile : Profile
    {
        public AirportDTOProfile()
        {
            CreateMap<Airport, AirportDTO>();
        }
    }
}
