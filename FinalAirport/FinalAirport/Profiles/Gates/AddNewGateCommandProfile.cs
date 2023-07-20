using AutoMapper;
using FinalAirport.Commands.Gates;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Gates
{
    public class AddNewGateCommandProfile : Profile
    {
        public AddNewGateCommandProfile()
        {
            CreateMap<GateDTO, AddNewGateCommand>();
        }
    }
}
