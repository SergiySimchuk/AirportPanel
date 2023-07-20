using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Gates
{
    public class UpdateGateCommandProfile : Profile
    {
        public UpdateGateCommandProfile()
        {
            CreateMap<GateDTO, UpdateGateCommand>();
        }
    }
}
