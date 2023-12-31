﻿using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure.Repositories
{
    public class PriceListRepository : IPriceListRepository
    {
        private readonly FinalAirportDBContext context;

        public PriceListRepository(FinalAirportDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> CtreateNewPriceList(PriceList priceList)
        {
            try
            {
                await this.context.PriceLists.AddAsync(priceList);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during creating new price list {ex?.InnerException?.Message}");
            }
        }

        public async Task<ICollection<PriceList>> GetPriceListsByFlight(Flight flight)
        {
            var res = this.context.PriceLists.Where(priceList => priceList.Flight == flight).ToList();
            return res;
        }

        public async Task<bool> RemovePriceList(PriceList priceList)
        {
            try
            {
                this.context.PriceLists.Remove(priceList);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing price list {ex?.InnerException?.Message}");
            }
        }

        public async Task<bool> UpdatePriceList(PriceList priceList)
        {
            try
            {
                this.context.PriceLists.Update(priceList);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating price list {ex?.InnerException?.Message}");
            }
        }
    }
}
