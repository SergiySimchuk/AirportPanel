using AutoMapper;
using AirportPanel.Commands.Gates;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Gates
{
    public class UpdateGateCommandProfile : Profile
    {
        public UpdateGateCommandProfile()
        {
            CreateMap<GateDTO, UpdateGateCommand>();
        }
    }
}
