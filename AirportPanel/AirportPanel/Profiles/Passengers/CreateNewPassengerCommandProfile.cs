using AutoMapper;
using AirportPanel.Commands.Passengers;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Passengers
{
    public class CreateNewPassengerCommandProfile : Profile
    {
        public CreateNewPassengerCommandProfile()
        {
            CreateMap<PassengerDTO, CreateNewPassengerCommand>();
        }
    }
}
