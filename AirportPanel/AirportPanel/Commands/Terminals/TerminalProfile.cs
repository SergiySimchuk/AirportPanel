using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.Domain;

namespace AirportPanel.Commands.Terminals
{
    public class TerminalProfile : Profile
    {
        public TerminalProfile()
        {
            CreateMap<GetGatesByTerminalCommand, Terminal>();
        }
    }
}
