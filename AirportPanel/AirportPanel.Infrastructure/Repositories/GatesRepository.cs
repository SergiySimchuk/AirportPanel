using AirportPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure
{
    public class GatesRepository : IGatesRepository
    {
        private readonly AirportPanelDBContext context;

        public GatesRepository(AirportPanelDBContext airportPanelDBContext)
        {
            this.context = airportPanelDBContext;
        }

        public async Task<bool> CreateNewGate(Gate gate)
        {
            try
            {
               await this.context.AddAsync(gate);
               await this.context.SaveChangesAsync();
               return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex?.InnerException?.Message);
            }
        }

        public async Task<ICollection<Gate>> GetAll()
        {
            return this.context.Gates.ToList();
        }

        public async Task<ICollection<Gate>> GetGatesByTerminal(Terminal terminal)
        {
            return this.context.Gates.Where((gate) => gate.Terminal == terminal).ToList();
        }

        public async Task<bool> RemoveGate(Gate gate)
        {
            try
            {
                this.context.Gates.Remove(gate);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during removing gate {ex?.InnerException?.Message}");
            }
        }

        public async Task<bool> UpdateGate(Gate gate)
        {
            try
            {
                this.context.Gates.Update(gate);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating gate {ex?.InnerException?.Message}");
            }
        }
    }
}
