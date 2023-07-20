using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure
{
    public  interface IGatesRepository
    {
        Task<ICollection<Gate>> GetAll();
        Task<bool> CreateNewGate(Gate gate);
        Task<bool> UpdateGate(Gate gate);
        Task<bool> RemoveGate(Gate gate);
        Task<ICollection<Gate>> GetGatesByTerminal (Terminal terminal);
    }
}
