using AutoMapper;
using FinalAirport.Commands.Passengers;
using FinalAirport.Commands.Tickets;
using FinalAirport.Commands.Users;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<GetPassengersByUserCommand, User>();
            CreateMap<GetTicketsByUserCommand, User>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<RemoveUserCommand, User>();
        }
    }
}
