using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Gates
{
    public class GateProfile : Profile
    {
        public GateProfile()
        {
            CreateMap<AddNewGateCommand, Gate>();
            CreateMap<RemoveGateCommand, Gate>();
            CreateMap<UpdateGateCommand, Gate>();
        }
    }
}
