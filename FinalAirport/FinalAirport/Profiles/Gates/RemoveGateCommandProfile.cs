using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.DTO;
using FinalAirport.Handlers.Tickets;

namespace FinalAirport.Profiles.Gates
{
    public class RemoveGateCommandProfile : Profile
    {
        public RemoveGateCommandProfile()
        {
            CreateMap<GateDTO, RemoveGateCommand>();
        }
    }
}
