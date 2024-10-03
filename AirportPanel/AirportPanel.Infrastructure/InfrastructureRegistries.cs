using AirportPanel.Infrastructure.Abstracts;
using AirportPanel.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure
{
    public static class InfrastructureRegistries
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFlightsPanelRepository, FlightsPanelRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IAirportRepository, AirportRepository>();
            serviceCollection.AddTransient<ITerminalRepository, TerminalRepository>();
            serviceCollection.AddTransient<IGatesRepository, GatesRepository>();
            serviceCollection.AddTransient<IFlightRepository, FlightsRepository>();
            serviceCollection.AddTransient<IFlightStatusRepository, FlightStatusRepository>();
            serviceCollection.AddTransient<IPriceClassesRepository, PriceClasseRepository>();
            serviceCollection.AddTransient<IPriceListRepository, PriceListRepository>();
            serviceCollection.AddTransient<IPassengerRepository, PassengerRepository>();
            serviceCollection.AddTransient<ITicketRepository, TicketRepository>();
            serviceCollection.AddTransient<ITokensRepository, TokenRepository>();
        }
    }
}   
