using AutoMapper;
using AirportPanel.Commands.Airports;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Airports
{
    public class RemoveAirportCommandProfile : Profile
    {
        public RemoveAirportCommandProfile()
        {
            CreateMap<AirportDTO, RemoveAirportCommand>();
        }
    }
}
