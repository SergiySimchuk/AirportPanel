using AutoMapper;
using AirportPanel.Commands.Airports;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Airports
{
    public class AddNewAirportCommandProfile : Profile
    {
        public AddNewAirportCommandProfile()
        {
            CreateMap<AirportDTO, AddNewAirportCommand>();
        }
    }
}
