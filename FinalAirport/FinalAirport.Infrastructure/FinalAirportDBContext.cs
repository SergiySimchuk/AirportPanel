using Microsoft.EntityFrameworkCore;
using FinalAirport.Domain;
using System.Data;

namespace FinalAirport.Domain
{
    public class FinalAirportDBContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<FlightStatus> FlightStatuses { get; set; }
        public DbSet<FlightsPanel> FlightsPanel { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<PriceClass> PriceClasses { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<JWTToken> JWTTokens { get; set; }
        public FinalAirportDBContext(DbContextOptions<FinalAirportDBContext> options) : base(options)
        {
            
        }
    }
}
