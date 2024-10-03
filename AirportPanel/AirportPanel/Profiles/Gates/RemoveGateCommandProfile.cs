using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.DTO;
using AirportPanel.Handlers.Tickets;

namespace AirportPanel.Profiles.Gates
{
    public class RemoveGateCommandProfile : Profile
    {
        public RemoveGateCommandProfile()
        {
            CreateMap<GateDTO, RemoveGateCommand>();
        }
    }
}
