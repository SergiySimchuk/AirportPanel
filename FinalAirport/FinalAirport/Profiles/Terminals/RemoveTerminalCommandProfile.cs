using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Terminals
{
    public class RemoveTerminalCommandProfile : Profile
    {
        public RemoveTerminalCommandProfile()
        {
            CreateMap<TerminalDto, RemoveTerminalCommand>();
        }
    }
}
