using AutoMapper;
using AirportPanel.Commands.Terminals;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Terminals
{
    public class AddNewTerminalCommandProfile : Profile
    {
        public AddNewTerminalCommandProfile()
        {
            CreateMap<TerminalDto, AddNewTerminalCommand>();
        }
    }
}
