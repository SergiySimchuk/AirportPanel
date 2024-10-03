using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Tickets
{
    public class UpdateTicketCommandProfile : Profile
    {
        public UpdateTicketCommandProfile()
        {
            CreateMap<TicketDTO, UpdateTicketCommand>();
        }
    }
}
