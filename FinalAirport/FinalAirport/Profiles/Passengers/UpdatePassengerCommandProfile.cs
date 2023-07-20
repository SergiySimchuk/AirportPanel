using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.DTO;

namespace FinalAirport.Profiles.Passengers
{
    public class UpdatePassengerCommandProfile : Profile
    {
        public UpdatePassengerCommandProfile()
        {
            CreateMap<PassengerDTO, UpdatePassengerCommand>();
        }
    }
}
