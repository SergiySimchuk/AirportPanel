using AutoMapper;
using AirportPanel.Commands.Airports;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Airports
{
    public class UpdateAirportCommandProfile : Profile
    {
        public UpdateAirportCommandProfile()
        {
            CreateMap<AirportDTO, UpdateAirportCommand>();
        }
    }
}
