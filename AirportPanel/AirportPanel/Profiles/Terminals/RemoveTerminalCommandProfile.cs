using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Terminals
{
    public class RemoveTerminalCommandProfile : Profile
    {
        public RemoveTerminalCommandProfile()
        {
            CreateMap<TerminalDto, RemoveTerminalCommand>();
        }
    }
}
