using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure
{
    public interface IFlightsPanelRepository
    {
        Task<ICollection<FlightsPanel>> GetAll();
        Task<FlightsPanel> GetFlightPanelById(int id);
        Task<ICollection<FlightsPanel>> GetCollectionWithCondition(string flightNumber, string departureAirport, string arrivalAirport, DateTime startDate, DateTime endDate);
    }
}
