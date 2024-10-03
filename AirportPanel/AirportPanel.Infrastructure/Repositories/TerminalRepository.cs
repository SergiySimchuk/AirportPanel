using AirportPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirportPanel.Infrastructure
{
    public class TerminalRepository : ITerminalRepository
    {
        private readonly AirportPanelDBContext context;

        public TerminalRepository(AirportPanelDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewTerminal(Terminal terminal)
        {
            try
            {
                await this.context.Terminals.AddAsync(terminal);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during adding terminal {ex?.InnerException?.Message}");
            } 
        }

        public async Task<bool> RemoveTerminal(Terminal terminal)
        {
            try
            {
                this.context.Terminals.Remove(terminal);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Error occur during updating terminal {ex?.InnerException?.Message}");
            }
        }

        public async Task<ICollection<Terminal>> GetAll()
        {
            return this.context.Terminals.ToList<Terminal>();
        }

        public async Task<bool> UpdateTerminal(Terminal terminal)
        {
            try
            {
                this.context.Terminals.Update(terminal);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {               
                throw new ApplicationException($"Error occur during updating terminal {ex?.InnerException?.Message}");
            }
        }

        public async Task<ICollection<Terminal>> GetTerminalsByAirport(Airport airport)
        {
            return this.context.Terminals.Where((terminal)=>terminal.Airport == airport).ToList();
        }
    }
}
