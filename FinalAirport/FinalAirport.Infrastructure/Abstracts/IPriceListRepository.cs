using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure.Abstracts
{
    public interface IPriceListRepository
    {
        Task<ICollection<PriceList>> GetPriceListsByFlight(Flight flight);
        Task<ICollection<PriceList>> GetPriceListsByFlightOnDate(Flight flight, DateTime date);
        Task<bool> CtreateNewPriceList(PriceList priceList);
        Task<bool> UpdatePriceList(PriceList priceList);
        Task<bool> RemovePriceList(PriceList priceList);
    }
}
