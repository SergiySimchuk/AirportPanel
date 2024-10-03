using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Terminals
{
    public class GetTerminalsByAirportCommandProfile : Profile
    {
        public GetTerminalsByAirportCommandProfile()
        {
            CreateMap<AirportDTO, GetTerminalsByAirportCommand>();
        }
    }
}
