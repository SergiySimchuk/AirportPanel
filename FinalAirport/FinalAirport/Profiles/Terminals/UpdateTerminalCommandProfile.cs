using AutoMapper;
using FinalAirport.Commands.Terminals;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Terminals
{
    public class UpdateTerminalCommandProfile : Profile
    {
        public UpdateTerminalCommandProfile()
        {
            CreateMap<TerminalDto, UpdateTerminalCommand>();
        }
    }
}
