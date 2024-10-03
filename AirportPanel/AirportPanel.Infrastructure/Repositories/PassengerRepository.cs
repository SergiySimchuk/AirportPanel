using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AirportPanelDBContext context;

        public PassengerRepository(AirportPanelDBContext context)
        {
            this.context = context; 
        }
        public async Task<Passenger> CreateNewPassenger(Passenger passenger)
        {
            try
            {
                await this.context.Passengers.AddAsync(passenger);
                await this.context.SaveChangesAsync();

                return passenger;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during adding passenger {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<ICollection<Passenger>> GetAll()
        {
            return this.context.Passengers.ToList();
        }

        public async Task<Passenger> GetPassengerByID(int id)
        {
            return  this.context.Passengers.FirstOrDefault(passenger=>passenger.Id == id);
        }

        public async Task<ICollection<Passenger>> GetPassengersByUser(User user)
        {
            return  this.context.Passengers.Where(passenger => passenger.User == user).ToList();
        }

        public async Task<bool> RemovePassenger(Passenger passenger)
        {
            try
            {
                this.context.Passengers.Remove(passenger);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing passenger {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<Passenger> UpdatePassenger(Passenger passenger)
        {
            try
            {
                this.context.Passengers.Update(passenger);
                await this.context.SaveChangesAsync();

                return passenger;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating passenger {ex?.InnerException?.Message}", ex);
            }
        }
    }
}
