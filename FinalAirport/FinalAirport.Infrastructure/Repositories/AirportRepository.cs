
using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FinalAirportDBContext context;

        public AirportRepository(FinalAirportDBContext context)
        {
            this.context = context;
        }

        public async Task <bool> CreateNewAirport(Airport airport)
        {
            try
            {
                await this.context.Airports.AddAsync(airport);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during saving airport: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAirport(Airport airport)
        {
            try
            {
                this.context.Airports.Remove(airport);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error uccur during removing airport: {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<ICollection<Airport>> GetAll()
        {
            return this.context.Airports.ToList();
        }

        public async Task<bool> UpdateAirport(Airport airport)
        {
            try
            {
                this.context.Airports.Update(airport);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurs during updating airport: {ex?.InnerException?.Message}");
            }
        }
    }
}
