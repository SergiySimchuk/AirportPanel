using AirportPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirportPanel.Infrastructure
{
    public class FlightsPanelRepository : IFlightsPanelRepository
    {
        private readonly AirportPanelDBContext context;

        public FlightsPanelRepository(AirportPanelDBContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<FlightsPanel>> GetAll()
        {
            //var result = this.context.FlightsPanel.ToList();
            var result = context.FlightsPanel.FromSqlRaw<FlightsPanel>("exec [dbo].[CalculateFlightPanelWithStatuses]").ToList();
            return result;
        }

        public async Task<ICollection<FlightsPanel>> GetCollectionWithCondition(string flightNumber, string departureAirport, string arrivalAirport, DateTime startDate, DateTime endDate)
        {
            var flights = context.FlightsPanel.FromSqlRaw<FlightsPanel>("exec [dbo].[CalculateFlightPanelWithStatuses]").ToList();

            if (!string.IsNullOrEmpty(flightNumber))
            {
                flights = flights.FindAll(flightsPanel=>  flightsPanel.FlightNumber.IndexOf(flightNumber, 0, StringComparison.OrdinalIgnoreCase) != -1);
            }
            
            if (!string.IsNullOrEmpty(departureAirport))
            {
                flights = flights.FindAll(flightsPanel=>  flightsPanel.DepartureAirport.IndexOf(departureAirport,0, StringComparison.OrdinalIgnoreCase) != -1);
            }

            if (!string.IsNullOrEmpty(arrivalAirport))
            {
                flights = flights.FindAll(flightsPanel => flightsPanel.ArrivalAirport.IndexOf(arrivalAirport,0, StringComparison.OrdinalIgnoreCase) != -1);
            }

            if (startDate != DateTime.MinValue)
            {
                flights = flights.FindAll(flightsPanel => flightsPanel.DepartureDateTime >= startDate);
            }

            if (endDate != DateTime.MinValue)
            {
                flights = flights.FindAll(flightsPanel => flightsPanel.ArrivalDateTime <= endDate);
            }

            return flights.ToList();
        }

        public async Task<FlightsPanel> GetFlightPanelById(int id)
        {
            return this.context.FlightsPanel.FirstOrDefault(flightPanelRow => flightPanelRow.ID == id);
        }
    }
}
