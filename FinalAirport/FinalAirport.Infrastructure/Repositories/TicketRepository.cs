using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FinalAirportDBContext context;

        public TicketRepository(FinalAirportDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewTicket(Ticket ticket)
        {
            try
            {
                await this.context.Tickets.AddAsync(ticket);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during creating ticket {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<ICollection<Ticket>> GetAll()
        {
            return this.context.Tickets.ToList();
        }

        public async Task<ICollection<Ticket>> GetTicketsByConditions(string flightNumber, string firstName, string lastName, string passport)
        {
            var tickets = this.context.Tickets.ToList(); 

            if (!string.IsNullOrEmpty(flightNumber))
            {
                tickets = tickets.FindAll(ticket=>ticket.Flight.FlightNumber.IndexOf(flightNumber, StringComparison.OrdinalIgnoreCase) != -1);
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                tickets = tickets.FindAll(ticket => ticket.Passenger.FirstName.IndexOf(firstName, StringComparison.OrdinalIgnoreCase) != -1);
            }
            
            if (!string.IsNullOrEmpty(lastName))
            {
                tickets = tickets.FindAll(ticket => ticket.Passenger.LastName.IndexOf(lastName, StringComparison.OrdinalIgnoreCase) != -1);
            }
            
            if (!string.IsNullOrEmpty(passport))
            {
                tickets = tickets.FindAll(ticket => ticket.Passenger.Passport.IndexOf(passport, StringComparison.OrdinalIgnoreCase) != -1);
            }

            return tickets.ToList();                
        }

        public async Task<ICollection<Ticket>> GetTicketsByPassenger(Passenger passenger)
        {
            return this.context.Tickets.Where(ticket => ticket.Passenger == passenger).ToList();
        }

        public async Task<ICollection<Ticket>> GetTicketsByUser(User user)
        {
            return this.context.Tickets.Where(ticket => ticket.Passenger.User == user).ToList();
        }

        public async Task<bool> RemoveTicket(Ticket ticket)
        {
            try
            {
                this.context.Tickets.Remove(ticket);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing ticket {ex?.InnerException?.Message}");
            }
        }

        public async Task<bool> UpdateTicket(Ticket ticket)
        {
            try
            {
                this.context.Tickets.Update(ticket);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating ticket {ex?.InnerException?.Message}");
            }
        }
    }
}
