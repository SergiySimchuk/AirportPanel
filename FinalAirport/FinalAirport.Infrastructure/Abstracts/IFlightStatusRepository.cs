using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure.Abstracts
{
    public interface IFlightStatusRepository
    {
        Task<ICollection<FlightStatus>> GetAll();
        Task<bool> CreateNewFlightStatus(FlightStatus flightStatus);
        Task<bool> RemoveFlightStatus(FlightStatus flightStatus);
        Task<bool> UpdateFlightStatus(FlightStatus flightStatus);
    }
}
