using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAirport;

namespace FinalAirport.Infrastructure
{
    public interface IAirportRepository
    {
        Task<ICollection<Airport>> GetAll();
        Task<bool> CreateNewAirport(Airport airport);
        Task<bool> DeleteAirport(Airport airport);
        Task<bool> UpdateAirport(Airport airport);
    }
}
