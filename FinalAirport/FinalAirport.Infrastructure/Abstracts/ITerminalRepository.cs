using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure
{
    public interface ITerminalRepository
    {
        Task<ICollection<Terminal>> GetAll();
        Task<bool> CreateNewTerminal(Terminal terminal);
        Task<bool> RemoveTerminal(Terminal terminal);
        Task<bool> UpdateTerminal(Terminal terminal);
        Task<ICollection<Terminal>> GetTerminalsByAirport(Airport airport);
    }
}
