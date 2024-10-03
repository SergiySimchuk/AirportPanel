using AirportPanel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel.Infrastructure.Abstracts
{
    public interface ITokensRepository
    {
        Task AddToken(JWTToken token);
        Task<JWTToken> GetToken(string token);
        Task<JWTToken> GetToken(string token, string refreshToken);
    }
}
