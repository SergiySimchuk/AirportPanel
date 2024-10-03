using AutoMapper;
using AirportPanel.Commands.Tickets;
using AirportPanel.DTO;

namespace AirportPanel.Profiles.Tickets
{
    public class GetTicketsByConditionsCommandProfile : Profile
    {
        public GetTicketsByConditionsCommandProfile()
        {
            CreateMap<TicketSearchConditions, GetTicketsByConditionsCommand>();
        }
    }
}
