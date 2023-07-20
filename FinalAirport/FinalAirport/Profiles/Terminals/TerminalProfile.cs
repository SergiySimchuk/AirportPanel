using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Terminals
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
