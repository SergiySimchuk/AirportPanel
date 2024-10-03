using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Tickets
{
    public class CreateNewTicketCommandProfile : Profile
    {
        public CreateNewTicketCommandProfile()
        {
            CreateMap<TicketDTO, CreateTicketCommand>();
        }
    }
}
