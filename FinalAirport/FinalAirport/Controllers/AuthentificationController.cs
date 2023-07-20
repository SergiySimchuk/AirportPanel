using AutoMapper;
using FinalAirport.Bearers;
using FinalAirport.DTO;
using FinalAirport.Handlers.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FinalAirport.Controllers
{
    public class AuthentificationController : ControllerBase
    {
        private IMediator mediator;
        private IMapper mapper;
        private IJWTTokenManager jwtTokenManager;

        public AuthentificationController(IMediator mediator, IMapper mapper, IJWTTokenManager jwtTokenManager)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.jwtTokenManager = jwtTokenManager;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(string login, string password, bool itStaff)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            var command = new GetUserByLoginPasswordStaffCommand 
            { 
                Login = login,
                Password = password,
                Staff = itStaff 
            };

            var domainUser = await mediator.Send(command);

            if (domainUser == null)
            {
                return Unauthorized();
            }

            var response = await jwtTokenManager.Authenticate(domainUser, ip);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PingJWTToken()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateToken([FromBody] UpdateTokensDTO tokens)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();

            var authResponse = await jwtTokenManager.UpdateToken(tokens.Token, tokens.RefreshToken, ip);

            return Ok(authResponse);
        }
    }
}
