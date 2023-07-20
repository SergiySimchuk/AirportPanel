using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Terminals
{
    public class AddNewTerminalCommandProfile : Profile
    {
        public AddNewTerminalCommandProfile()
        {
            CreateMap<TerminalDto, AddNewTerminalCommand>();
        }
    }
}
