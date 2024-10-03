using AirportPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Abstracts
{
    public interface IFlightRepository
    {
        Task<bool> CreateNewFlight(Flight flight);
        Task<Flight> GetFlightById(int id);
        Task<bool> UpdadeFlight(Flight flight);
        Task<bool> RemoveFlight(Flight flight);
    }
}
