using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Passengers
{
    public class CreateNewPassengerCommandProfile : Profile
    {
        public CreateNewPassengerCommandProfile()
        {
            CreateMap<PassengerDTO, CreateNewPassengerCommand>();
        }
    }
}
