using AutoMapper;
using FinalAirport.Commands.Tickets;
using FinalAirport.Domain;

namespace FinalAirport.Profiles.Tickets
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<CreateTicketCommand, Ticket>();
            CreateMap<UpdateTicketCommand, Ticket>();
            CreateMap<RemoveTicketCommand, Ticket>();
        }
    }
}
