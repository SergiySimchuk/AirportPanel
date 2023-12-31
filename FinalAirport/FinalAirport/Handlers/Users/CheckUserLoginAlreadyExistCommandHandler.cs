﻿using FinalAirport.Commands.Users;
using FinalAirport.Infrastructure;
using MediatR;

namespace FinalAirport.Handlers.Users
{
    public class CheckUserLoginAlreadyExistCommandHandler : IRequestHandler<CheckUserLoginAlreadyExistCommand, bool>
    {
        private readonly IUserRepository repsitory;

        public CheckUserLoginAlreadyExistCommandHandler(IUserRepository repsitory)
        {
            this.repsitory = repsitory;
        }
        public async Task<bool> Handle(CheckUserLoginAlreadyExistCommand request, CancellationToken cancellationToken)
        {
            return await this.repsitory.CheckLoginAlreadyExist(request.Login);
        }
    }
}
