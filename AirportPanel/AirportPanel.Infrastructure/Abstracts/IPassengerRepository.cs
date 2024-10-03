using AirportPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Abstracts
{
    public interface IPassengerRepository
    {
        Task<ICollection<Passenger>> GetAll();
        Task<Passenger> CreateNewPassenger(Passenger passenger);
        Task<Passenger> UpdatePassenger(Passenger passenger);
        Task<bool> RemovePassenger(Passenger passenger);
        Task<ICollection<Passenger>> GetPassengersByUser(User user);
        Task<Passenger> GetPassengerByID(int id);
    }
}
