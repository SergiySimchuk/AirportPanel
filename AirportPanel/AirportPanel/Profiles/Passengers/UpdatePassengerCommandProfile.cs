using AutoMapper;
using AirportPanel.Commands.Passengers;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Passengers
{
    public class UpdatePassengerCommandProfile : Profile
    {
        public UpdatePassengerCommandProfile()
        {
            CreateMap<PassengerDTO, UpdatePassengerCommand>();
        }
    }
}
