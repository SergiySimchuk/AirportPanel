using FinalAirport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAirport.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly FinalAirportDBContext context;

        public UserRepository(FinalAirportDBContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckLoginAlreadyExist(string login)
        {
            return this.context.Users.Where(user => user.Login == login).Count() > 0; 
        }

        public async Task<bool> CreateNewUser(User user)
        {
            try
            {
                await this.context.Users.AddAsync(user);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during adding new user {ex?.InnerException?.Message}", ex);
            }
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password, bool staff)
        {
            return this.context.Users.FirstOrDefault<User>(user => user.Login==login && user.Password==password && user.Staff == staff);
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            return this.context.Users.FirstOrDefault<User>(user => user.Login == login && user.Password == password);
        }

        public async Task<bool> RemoveUser(User user)
        {
            try
            {
                this.context.Users.Remove(user);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            { 
                throw new ApplicationException($"Error occur during Removing user {ex?.InnerException?.Message}", ex) ;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                this.context.Users.Update(user);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occur during updating user {ex?.InnerException?.Message}", ex);
            }
        }
    }
}
