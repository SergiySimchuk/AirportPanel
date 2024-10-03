using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Repositories
{
    public class FlightsRepository : IFlightRepository
    {
        private readonly AirportPanelDBContext context;

        public FlightsRepository(AirportPanelDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewFlight(Flight flight)
        {
            try
            {
                await this.context.Flights.AddAsync(flight);
                await context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during adding flight {ex?.InnerException?.Message}");
            }
        }

        public async Task<Flight> GetFlightById(int id)
        {
            return this.context.Flights.FirstOrDefault((flight) =>  flight.Id == id );
        }

        public async Task<bool> RemoveFlight(Flight flight)
        {
            try
            {
                this.context.Flights.Remove(flight);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing flight {ex?.InnerException?.Message}");
            }
        }

        public async Task<bool> UpdadeFlight(Flight flight)
        {
            try
            {
                this.context.Update(flight);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating flight {ex?.InnerException?.Message}"); 
            }
        }
    }
}
