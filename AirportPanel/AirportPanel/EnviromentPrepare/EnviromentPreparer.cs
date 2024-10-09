using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AirportPanel.Commands.Users;

namespace AirportPanel.EnviromentPrepare
{
    public class EnviromentPreparer : IEnviromentPreparer
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;

        public EnviromentPreparer(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;
            this.configuration = configuration;
        }

        public async Task Prepare()
        {
            await CreateAdminUserIFDoesntExist();
        }

        private async Task CreateAdminUserIFDoesntExist()
        {
            var adminSection = configuration.GetSection("DefaultAdmin");
            var adminLogin = adminSection.GetValue<string>("Login");

            var checkCommand = new CheckUserLoginAlreadyExistCommand() { Login = adminLogin };
            var userAlreadyExist = await mediator.Send(checkCommand);

            if (userAlreadyExist)
                return;

            var adminPassword = adminSection.GetValue<string>("Password");
            var createCommand = new CreateUserCommand() { Login = adminLogin, Password = adminPassword, Staff = true };

            await mediator.Send(createCommand);
        }
    }
}
