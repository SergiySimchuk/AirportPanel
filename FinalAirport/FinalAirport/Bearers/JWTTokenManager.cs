using FinalAirport.Domain;
using FinalAirport.DTO;
using FinalAirport.Infrastructure.Abstracts;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FinalAirport.Bearers
{
    public class JWTTokenManager : IJWTTokenManager
    {
        private readonly IConfiguration configuration;
        private readonly ITokensRepository tokensRepository;

        public JWTTokenManager(IConfiguration configuration, ITokensRepository tokensRepository)
        {
            this.configuration = configuration;
            this.tokensRepository = tokensRepository;
        }

        public async Task<AuthResponseDTO> Authenticate(User user, string ipAdress)
        {
            try
            {
                var lifeTime = configuration.GetValue<int>("JWTTokenLifeTime");
                var expires = DateTime.UtcNow.AddMinutes(lifeTime);

                var refreshLifeTime = configuration.GetValue<int>("RefreshTokenLifeTime");
                var refreshExpires = DateTime.UtcNow.AddDays(refreshLifeTime);

                var tokenString = GenerateJWTToken(expires, user.Login);
                var refreshToken = GenerateRefreshToken();

                CreateTokenModel(user, ipAdress, expires, refreshExpires, tokenString, refreshToken);

                var response = new AuthResponseDTO { IsSuccess = true, Token = tokenString, RefreshToken = refreshToken };

                return response;
            }
            catch (Exception ex)
            {
                return new AuthResponseDTO { IsSuccess = false, Message = "Authentification error"};
            }
        }

        private async void CreateTokenModel(User user, string ipAdress, DateTime expires, DateTime refreshExpires, string tokenString, string refreshToken)
        {
            var tokenModel =  new JWTToken
            {
                Token = tokenString,
                Expiration = expires,
                RefreshTokenExpiration = refreshExpires,
                IPAdress = ipAdress,
                RefreshToken = refreshToken,
                UserID = user.Id,
                Created = DateTime.UtcNow
            };

            await this.tokensRepository.AddToken(tokenModel);
        }

        private string GenerateJWTToken(DateTime expires, string userLogin)
        {
            var key = configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, userLogin) }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        private string GenerateRefreshToken()
        {
            var byteArray = new byte[64];

            using (var cryptoProv = new RNGCryptoServiceProvider())
            {
                cryptoProv.GetBytes(byteArray);

                return Convert.ToBase64String(byteArray);
            }
        }

        public async Task<AuthResponseDTO> UpdateToken(string token, string refreshToken, string ipAdress)
        {
            var tokenModel = await this.tokensRepository.GetToken(token, refreshToken);

            if (tokenModel == null)
                return new AuthResponseDTO { IsSuccess = false, Message = "Wrong tokens" };

            if (tokenModel.IPAdress != ipAdress)
                return new AuthResponseDTO { IsSuccess = false, Message = "Wrong IP adress" };

            var handler = new JwtSecurityTokenHandler();
            var tokenObject = handler.ReadJwtToken(token);

            if (tokenObject.ValidTo >= DateTime.UtcNow)
                return new AuthResponseDTO { IsSuccess = false, Message = "Token isn`t expired" };

            if (tokenModel.RefreshTokenExpiration < DateTime.UtcNow)
                return new AuthResponseDTO { IsSuccess = false, Message = "Refresh token expired" };

            var lifeTime = configuration.GetValue<int>("JWTTokenLifeTime");
            var expires = DateTime.UtcNow.AddMinutes(lifeTime);

            var newToken = GenerateJWTToken(expires, tokenModel.User.Login);

            CreateTokenModel(tokenModel.User, ipAdress, expires, tokenModel.RefreshTokenExpiration, newToken, refreshToken);

            return new AuthResponseDTO { IsSuccess = true, Token = newToken, RefreshToken = refreshToken};
        }
    }
}
