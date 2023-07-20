using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure.Abstracts
{
    public interface ITicketRepository
    {
        Task<ICollection<Ticket>> GetAll();
        Task<ICollection<Ticket>> GetTicketsByConditions(string flightNumber, string firstName, string lastName, string passport);
        Task<bool> CreateNewTicket(Ticket ticket);
        Task<bool> UpdateTicket(Ticket ticket);
        Task<bool> RemoveTicket(Ticket ticket);
        Task<ICollection<Ticket>> GetTicketsByPassenger(Passenger passenger);
        Task<ICollection<Ticket>> GetTicketsByUser(User user);
    }
}
