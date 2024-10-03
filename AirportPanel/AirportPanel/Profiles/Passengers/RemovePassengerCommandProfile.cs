using AutoMapper;
using AirportPanel.Commands.Passengers;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Passengers
{
    public class RemovePassengerCommandProfile : Profile
    {
        public RemovePassengerCommandProfile()
        {
            CreateMap<PassengerDTO, RemovePassengerCommand>();
        }
    }
}
