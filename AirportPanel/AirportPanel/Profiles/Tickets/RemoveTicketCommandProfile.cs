using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Tickets
{
    public class RemoveTicketCommandProfile : Profile
    {
        public RemoveTicketCommandProfile()
        {
            CreateMap<TicketDTO, RemoveTicketCommand>();
        }
    }
}
