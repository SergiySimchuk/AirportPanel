using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Gates
{
    public class GetGatesByTerminalCommandProfile : Profile
    {
        public GetGatesByTerminalCommandProfile()
        {
            CreateMap<TerminalDto, GetGatesByTerminalCommand>();
        }
    }
}
