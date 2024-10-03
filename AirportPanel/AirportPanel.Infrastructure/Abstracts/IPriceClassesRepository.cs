using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportPanel.Domain;

namespace AirportPanel.Infrastructure.Abstracts
{
    public interface IPriceClassesRepository
    {
        Task<ICollection<PriceClass>> GetAll();
        Task<bool> CreateNewPriceClass(PriceClass priceClass);
        Task<bool> RemovePriceClass(PriceClass priceClass);
        Task<bool> UpdatePriceClass(PriceClass priceClass);
    }
}
