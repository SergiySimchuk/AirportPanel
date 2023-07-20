using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Gates
{
    public class GetGatesByTerminalCommandProfile : Profile
    {
        public GetGatesByTerminalCommandProfile()
        {
            CreateMap<TerminalDto, GetGatesByTerminalCommand>();
        }
    }
}
