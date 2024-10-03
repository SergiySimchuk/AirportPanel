using AutoMapper;
using AirportPanel.Domain;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Airports
{
    public class AirportDTOProfile : Profile
    {
        public AirportDTOProfile()
        {
            CreateMap<Airport, AirportDTO>();
        }
    }
}
