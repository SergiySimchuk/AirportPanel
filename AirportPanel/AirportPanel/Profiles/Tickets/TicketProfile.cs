using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.Domain;

namespace AirportPanel.Profiles.Tickets
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
