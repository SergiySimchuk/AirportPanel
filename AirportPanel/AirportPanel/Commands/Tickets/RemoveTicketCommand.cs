using MediatR;

namespace AirportPanel.Commands.Tickets
{
    public class RemoveTicketCommand : IRequest<ActionResponse>
    {
        public int Id { get; set; }
    }
}
