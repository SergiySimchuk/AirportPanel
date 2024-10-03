using AutoMapper;
using AirportPanel.Commands.Passengers;
using AirportPanel.Commands.Tickets;
using AirportPanel.Commands.Users;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Users
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
