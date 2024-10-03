using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Gates
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
