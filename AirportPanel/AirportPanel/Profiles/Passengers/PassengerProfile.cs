using AutoMapper;
using AirportPanel.Commands.Passengers;
using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Passengers
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
