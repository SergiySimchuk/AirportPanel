using AutoMapper;
using FinalAirport.Bearers;
using FinalAirport.Commands.Tokens;
using FinalAirport.Commands.Users;
using FinalAirport.DTO;
using FinalAirport.Handlers.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAirport.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private IMediator mediator;
        private IMapper mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentAuthorizedUser([FromHeader] string authorization)
        {
            var token = authorization.Replace("Bearer ", string.Empty);

            var command = new GetTokenCommand { Token = token };

            var tokenModel = await this.mediator.Send(command);

            var userDTO = this.mapper.Map<UserDTO>(tokenModel.User);

            return Ok(userDTO);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateNewUser([FromBody] UserDTO user)
        {
            var response = new UserDTO();

            var commandCheck = new CheckUserLoginAlreadyExistCommand() { Login = user.Login };
            var exist = await mediator.Send(commandCheck);

            if (exist)
            {
                response.Result = false;
                response.Message = "User with this login already exist";
                return Ok(response);
            }

            var commandCreate = this.mapper.Map<CreateUserCommand>(user);

            try
            {
                var result = await this.mediator.Send(commandCreate);
                response.Result = true;
                response.Id = result.Id;
                response.Login = result.Login;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;

                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            var command = this.mapper.Map<UpdateUserCommand>(user);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser([FromBody] UserDTO user)
        {
            var command = this.mapper.Map<RemoveUserCommand>(user);

            var result = await this.mediator.Send(command);

            return Ok(result);
        }
    }
}
