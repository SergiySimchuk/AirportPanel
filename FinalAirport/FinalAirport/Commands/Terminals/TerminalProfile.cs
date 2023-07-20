using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.Domain;

namespace FinalAirport.Commands.Terminals
{
    public class TerminalProfile : Profile
    {
        public TerminalProfile()
        {
            CreateMap<GetGatesByTerminalCommand, Terminal>();
        }
    }
}
