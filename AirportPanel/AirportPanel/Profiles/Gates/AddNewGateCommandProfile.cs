using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Gates
{
    public class AddNewGateCommandProfile : Profile
    {
        public AddNewGateCommandProfile()
        {
            CreateMap<GateDTO, AddNewGateCommand>();
        }
    }
}
