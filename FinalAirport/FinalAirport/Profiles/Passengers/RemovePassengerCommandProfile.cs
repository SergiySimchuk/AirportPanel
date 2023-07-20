using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Passengers
{
    public class RemovePassengerCommandProfile : Profile
    {
        public RemovePassengerCommandProfile()
        {
            CreateMap<PassengerDTO, RemovePassengerCommand>();
        }
    }
}
