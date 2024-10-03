using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Terminals
{
    public class UpdateTerminalCommandProfile : Profile
    {
        public UpdateTerminalCommandProfile()
        {
            CreateMap<TerminalDto, UpdateTerminalCommand>();
        }
    }
}
