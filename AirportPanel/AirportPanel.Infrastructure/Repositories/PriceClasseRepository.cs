using AirportPanel.Domain;
using AirportPanel.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Repositories
{
    public class PriceClasseRepository : IPriceClassesRepository
    {
        private readonly AirportPanelDBContext context;

        public PriceClasseRepository(AirportPanelDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewPriceClass(PriceClass priceClass)
        {
            try
            {
                await this.context.PriceClasses.AddAsync(priceClass);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during creating price class {ex?.InnerException?.Message}");
            }
        }

        public async Task<ICollection<PriceClass>> GetAll()
        {
            return this.context.PriceClasses.ToList();
        }

        public async Task<bool> RemovePriceClass(PriceClass priceClass)
        {
            try
            {
                this.context.PriceClasses.Remove(priceClass);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing price class {ex?.InnerException?.Message}");
            }
        }

        public async Task<bool> UpdatePriceClass(PriceClass priceClass)
        {
            try
            {
                this.context.PriceClasses.Update(priceClass);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating price class {ex?.InnerException?.Message}");
            }
        }
    }
}
