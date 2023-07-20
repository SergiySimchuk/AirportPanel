using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure
{
    public interface IUserRepository
    {
        Task<User> GetUserByLoginAndPassword(string login, string password, bool staff);
        Task<User> GetUserByLoginAndPassword(string login, string password);
        Task<bool> CheckLoginAlreadyExist(string login);
        Task<bool> CreateNewUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> RemoveUser(User user);
    }
}
