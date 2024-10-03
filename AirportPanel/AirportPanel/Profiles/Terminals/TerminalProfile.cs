using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Terminals
{
    public class TerminalProfile : Profile
    {
        public TerminalProfile()
        {
            CreateMap<AddNewTerminalCommand, Terminal>();
            CreateMap<RemoveTerminalCommand, Terminal>();
            CreateMap<UpdateTerminalCommand, Terminal>();
        }
    }
}
