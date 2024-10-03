using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Repositories
{
    public class FlightStatusRepository : IFlightStatusRepository
    {
        private readonly AirportPanelDBContext context;

        public FlightStatusRepository(AirportPanelDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewFlightStatus(FlightStatus flightStatus)
        {
            try
            {
                await this.context.FlightStatuses.AddAsync(flightStatus);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during adding flight status {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<ICollection<FlightStatus>> GetAll()
        {
            return this.context.FlightStatuses.ToList();
        }

        public async Task<bool> RemoveFlightStatus(FlightStatus flightStatus)
        {
            try
            {
                this.context.FlightStatuses.Remove(flightStatus);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing flight status {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<bool> UpdateFlightStatus(FlightStatus flightStatus)
        {
            try
            {
                this.context.FlightStatuses.Update(flightStatus);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating flight status {ex?.InnerException?.Message}", ex);
            }
        }
    }
}
