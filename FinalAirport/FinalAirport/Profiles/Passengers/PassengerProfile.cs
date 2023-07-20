using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Passengers
{
    public class PassengerProfile : Profile
    {
        public PassengerProfile()
        {
            CreateMap<CreateNewPassengerCommand, Passenger>();
            CreateMap<UpdatePassengerCommand, Passenger>();
            CreateMap<RemovePassengerCommand, Passenger>();
            CreateMap<GetTicketsByPassengerCommand, Passenger>();
        }
    }
}
