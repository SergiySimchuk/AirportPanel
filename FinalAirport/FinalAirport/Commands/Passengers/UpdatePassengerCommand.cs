﻿using FinalAirport.Domain;
using MediatR;

namespace FinalAirport.Commands.Passengers
{
    public class UpdatePassengerCommand : IRequest<Passenger>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }
    }
}
