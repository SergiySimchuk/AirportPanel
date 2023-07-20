using FinalAirport.Domain;
using FinalAirport.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure.Repositories
{
    public class TokenRepository : ITokensRepository
    {
        private readonly FinalAirportDBContext context;

        public TokenRepository(FinalAirportDBContext context)
        {
            this.context = context;
        }

        public async Task AddToken(JWTToken token)
        {
            try
            {
                this.context.JWTTokens.Add(token);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error during adding token {ex.Message}");
            } 
        }

        public async Task<JWTToken> GetToken(string token)
        {
            var tokenModel = this.context.JWTTokens.FirstOrDefault(entity => entity.Token == token);

            return tokenModel;
        }

        public async Task<JWTToken> GetToken(string token, string refreshToken)
        {
            var tokenModel = this.context.JWTTokens.FirstOrDefault(entity=>entity.Token==token && entity.RefreshToken == refreshToken);

            return tokenModel;
        }
    }
}
